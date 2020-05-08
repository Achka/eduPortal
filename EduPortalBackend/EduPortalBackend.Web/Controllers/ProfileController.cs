using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<User> userManager;

		public ProfileController(UserManager<User> userManager) => this.userManager = userManager;

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProfile(long id) {
			var user = await this.userManager.FindByIdAsync(id.ToString());
			if (user == null) {
				return NotFound();
			}

			return Json(await user.ConvertForProfile(this.userManager));
		}
	}
}
