using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.CustomAttributes;
using Services.StandardResponses;

namespace Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly IUnitOfWork db;
		private readonly IMapper mapper;
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<Role> roleManager;
		private readonly AuthService authService;

		public AuthController(IUnitOfWork db, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager, 
				RoleManager<Role> roleManager, AuthService authService) {
			this.db = db;
			this.mapper = mapper;
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.authService = authService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto model) {
			var user = await this.userManager.FindByEmailAsync(model.Email);
			if (user == null) {
				return BadRequest(new ApiBadRequestResponse(new[] { "Invalid email" }));
			}
			var result = await this.signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
			if (!result.Succeeded) {
				return BadRequest(new ApiBadRequestResponse(new[] { "Invalid password" }));
			}

			var accessToken = await this.authService.GenerateJwtAccessToken(user);
			var refreshToken = this.authService.GenerateRefreshToken(user);
			return Ok(new ApiOkResponse(new TokenDto { 
				AccessToken = accessToken,
				RefreshToken = refreshToken,
				UserId = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName
			}));
		}

		[AuthorizeRoles(Role.ADMIN)]
		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto model) {
			var user = this.mapper.Map<User>(model);
			using (var transaction = this.db.Context.Database.BeginTransaction()) {
				var createUserResult = await this.userManager.CreateAsync(user, model.Password);
				if (!createUserResult.Succeeded) {
					return BadRequest(new ApiBadRequestResponse(createUserResult.Errors.Select(error => error.Description)));
				}

				var roleExistResult = await this.roleManager.RoleExistsAsync(model.Role);
				if (!roleExistResult) {
					return BadRequest(new ApiBadRequestResponse(new[] { $"Role '{model.Role}' doesn't exist" }));
				}

				var addRoleToUserResult = await this.userManager.AddToRoleAsync(user, model.Role);
				if (!addRoleToUserResult.Succeeded) {
					return BadRequest(new ApiBadRequestResponse(addRoleToUserResult.Errors.Select(error => error.Description)));
				}

				await transaction.CommitAsync();
			}

			var accessToken = await this.authService.GenerateJwtAccessToken(user);
			var refreshToken = this.authService.GenerateRefreshToken(user);
			return Ok(new ApiOkResponse(new TokenDto {
				AccessToken = accessToken,
				RefreshToken = refreshToken,
				FirstName = user.FirstName,
				LastName = user.LastName
			}));
		}

		[HttpPost("token/refresh")]
		public async Task<IActionResult> RefreshToken([FromBody]string refreshToken) {
			var refreshTokenFromDb = this.db.RefreshTokens.GetAll(token => token.Token == refreshToken).SingleOrDefault();
			if (refreshTokenFromDb == null) {
				return Unauthorized(new ApiResponse(401, "There is no such token in database"));
			}

			if (refreshTokenFromDb.Expires < DateTime.UtcNow) {
				return Unauthorized(new ApiResponse(401, "Refresh token has expired. Please login again"));
			}

			var user = refreshTokenFromDb.User;
			if (this.userManager.SupportsUserLockout && await this.userManager.IsLockedOutAsync(user)) {
				return Unauthorized(new ApiResponse(401, "User is locked out"));
			}

			var accessToken = this.authService.GenerateJwtAccessToken(user);
			return Ok(new ApiOkResponse(accessToken));
		}

		[Authorize]
		[HttpGet("logout")]
		public IActionResult Logout() {
			var refreshToken = this.db.RefreshTokens
				.GetAll(token => token.UserId == long.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)))
				.SingleOrDefault();
			if (refreshToken == null) {
				return Unauthorized(new ApiResponse(401, "There is no such token in database"));
			}

			this.db.RefreshTokens.Delete(refreshToken);
			return Ok(new ApiOkResponse("Refresh token is deleted"));
		}
	}
}
