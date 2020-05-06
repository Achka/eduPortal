using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
	// Should be changed when adding ASP.NET Core Identity
	public class User
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PicturePath { get; set; }
		// Reference to ASP.NET Core role

		public DateTime? StudyingStart { get; set; }
		public DateTime? StudyingFinish { get; set; }

		// Contacts which should be added(many-to-many)
		//public List<Contact> Contacts { get; set; }
		public virtual List<UserCourse> UserCourses { get; set; }
	}
}
