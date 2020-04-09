using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
	public class Course
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public long AuthorId { get; set; }
		public User Author { get; set; }

		public List<Material> Materials { get; set; }
		public long MaterialSizeLimit { get; set; }

	}
}
