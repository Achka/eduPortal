using System.Linq;
using System.Threading.Tasks;
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
	[Route("api/[controller]/[action]")]
	public class AuthController : Controller
	{
		private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> userManager;
		private readonly AuthService authService;

		public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, AuthService authService) => 
			(this.signInManager, this.userManager, this.authService) = (signInManager, userManager, authService);

		[HttpPost]
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

		[HttpPost]
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
	}
}
