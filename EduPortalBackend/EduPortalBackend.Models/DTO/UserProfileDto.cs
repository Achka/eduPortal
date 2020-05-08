using System;

namespace Entities.DTO
{
	public class UserProfileDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PicturePath { get; set; }
		public string Role { get; set; }

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }
	}
}
