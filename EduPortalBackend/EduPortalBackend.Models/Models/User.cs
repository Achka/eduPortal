using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
	// Should be changed when adding ASP.NET Core Identity
	public class User : IdentityUser<long>
	{
		public string PicturePath { get; set; }
		// Reference to ASP.NET Core role

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }

		// Contacts which should be added(many-to-many)
		//public List<Contact> Contacts { get; set; }
		public virtual List<UserCourse> UserCourses { get; set; }
	}
}
