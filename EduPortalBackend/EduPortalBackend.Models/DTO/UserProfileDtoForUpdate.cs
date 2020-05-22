using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
	public class UserProfileDtoForUpdate
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string PicturePath { get; set; }

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }
	}
}
