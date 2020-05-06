using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
	public class Course
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int YearOfStudy { get; set; }

		public long AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		public User Author { get; set; }

		public List<Material> Materials { get; set; }
		public long MaterialSizeLimit { get; set; }

		public virtual List<UserCourse> UserCourses { get; set; }
	}
}
