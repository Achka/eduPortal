using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class User : IdentityUser<long>
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string PicturePath { get; set; }

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }

		// Contacts which should be added(many-to-many)
		//public List<Contact> Contacts { get; set; }
		public virtual List<UserCourse> UserCourses { get; set; }
	}
}
