using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.TransformationExtensions
{
	public static class UserTransformationExtension
	{
		public static async Task<UserProfileDto> Transform(this User user, UserManager<User> userManager) {
			return new UserProfileDto {
				FirstName = user.FirstName,
				LastName = user.LastName,
				PicturePath = user.PicturePath,
				StudyingStart = user.StudyingStart,
				StudyingFinish = user.StudyingFinish,
				Role = (await userManager.GetRolesAsync(user)).FirstOrDefault(),
			};
		}

		public static User Transform(this RegisterDto model) {
			return new User {
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.Email,
				Email = model.Email,
				StudyingStart = model.StudyingStart,
				StudyingFinish = model.StudyingFinish
			};
		}
	}
}
