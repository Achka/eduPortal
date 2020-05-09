using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Entities.TransformationExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.StandardResponses;

namespace Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly IUnitOfWork db;
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		private readonly AuthService authService;

		public AuthController(IUnitOfWork db, SignInManager<User> signInManager, UserManager<User> userManager, AuthService authService) {
			this.db = db;
			this.signInManager = signInManager;
			this.userManager = userManager;
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

			var refreshToken = this.authService.GenerateRefreshToken(user);
			var accessToken = this.authService.GenerateJwtAccessToken(user);
			return Ok(new ApiOkResponse(new TokenDto { 
				AccessToken = accessToken,
				RefreshToken = refreshToken,
				FirstName = user.FirstName,
				LastName = user.LastName
			}));
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto model) {
			var user = model.Transform();
			var result = await this.userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded) {
				return BadRequest(new ApiBadRequestResponse(result.Errors.Select(error => error.Description)));
			}

			var accessToken = this.authService.GenerateJwtAccessToken(user);
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
				return BadRequest(new ApiBadRequestResponse(new[] { "There is no such token in database" }));
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
	}
}
