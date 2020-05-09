using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Course
	{
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public int YearOfStudy { get; set; }

		public long AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		public virtual User Author { get; set; }

		public virtual List<Material> Materials { get; set; }
		public long MaterialSizeLimit { get; set; }

		public virtual List<UserCourse> UserCourses { get; set; }
	}
}
