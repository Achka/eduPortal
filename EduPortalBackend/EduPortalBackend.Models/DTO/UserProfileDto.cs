﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
	public class UserProfileDto
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string PicturePath { get; set; }
		public string Role { get; set; }

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }
	}
}
