using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.StandardResponses;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;

		public ProfileController(UserManager<User> userManager, IMapper mapper) {
			this.userManager = userManager;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProfile(long id) {
			var user = await this.userManager.FindByIdAsync(id.ToString());
			if (user == null) {
				return NotFound(new ApiResponse(404, $"User with id {id} not found"));
			}

			var userDto = this.mapper.Map<UserProfileDto>(user);
			userDto.Role = (await this.userManager.GetRolesAsync(user)).Single();
			return Ok(new ApiOkResponse(userDto));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProfile(long id, [FromBody]UserProfileDtoForUpdate userDto) {
			if (id != long.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier))) {
				return StatusCode(403, new ApiResponse(403, "Write access to other user account is forbidden"));
			}

			var user = await this.userManager.FindByIdAsync(id.ToString());
			if (user == null) {
				return NotFound(new ApiResponse(404, $"User with id {id} not found"));
			}

			user = this.mapper.Map(userDto, user);
			var result = await this.userManager.UpdateAsync(user);
			if (!result.Succeeded) {
				return StatusCode(500, new ApiResponse(500));
			}

			return NoContent();
		}
	}
}
