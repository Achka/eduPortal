using System.Threading.Tasks;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

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
			var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password,
				isPersistent: model.RememberMe, lockoutOnFailure: false);
			if (!result.Succeeded) {
				return BadRequest(new { errorText = "Invalid email or password" });
			}

			var user = await this.userManager.FindByEmailAsync(model.Email);
			var token = this.authService.GenerateJwtToken(user);
			return Json(new {
				access_token = token
			});
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterDto model) {
			var user = new User {
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.Email,
				Email = model.Email,
				StudyingStart = model.StudyingStart,
				StudyingFinish = model.StudyingFinish
			};
			var result = await this.userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded) {
				return BadRequest(result.Errors);
			}

			await this.signInManager.SignInAsync(user, false);
			var token = this.authService.GenerateJwtToken(user);
			return Json(new {
				access_token = token
			});
		}
	}
}
