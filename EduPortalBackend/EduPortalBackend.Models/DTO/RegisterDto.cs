using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
	public class RegisterDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[DataType(DataType.Date)]
		public DateTime? StudyingStart { get; set; }

		[DataType(DataType.Date)]
		public DateTime? StudyingFinish { get; set; }

		[Required]
		[StringLength(maximumLength: 100, MinimumLength = 6)]
		public string Password { get; set; }

		[Required]
		public string Role { get; set; }
	}
}
