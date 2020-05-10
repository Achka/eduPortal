using Entities.Models;
using Entities.TransformationExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.StandardResponses;
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
				return NotFound(new ApiResponse(404, $"User with id {id} not found"));
			}

			return Ok(new ApiOkResponse(await user.Transform(this.userManager)));
		}
	}
}
