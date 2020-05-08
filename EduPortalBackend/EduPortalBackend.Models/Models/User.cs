using Entities.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class User : IdentityUser<long>
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string PicturePath { get; set; }

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }

		// Contacts which should be added(many-to-many)
		//public List<Contact> Contacts { get; set; }
		public virtual List<UserCourse> UserCourses { get; set; }
	}

	public static class UserTransformationExtension
	{
		public static async Task<UserProfileDto> ConvertForProfile(this User user, UserManager<User> userManager) {
			return new UserProfileDto {
				FirstName = user.FirstName,
				LastName = user.LastName,
				PicturePath = user.PicturePath,
				StudyingStart = user.StudyingStart,
				StudyingFinish = user.StudyingFinish,
				Role = (await userManager.GetRolesAsync(user)).FirstOrDefault(),
			};
		}
	}
}
