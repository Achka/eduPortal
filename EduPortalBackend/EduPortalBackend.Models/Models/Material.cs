using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
	public class Material
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string DocumentPath { get; set; }
		public long Size { get; set; }
		public string Extension { get; set; }

		public long CourseId { get; set; }
		public Course Course { get; set; }
	}
}
