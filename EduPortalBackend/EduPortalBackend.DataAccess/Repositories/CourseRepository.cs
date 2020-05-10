using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="Course"/> specific methods
	/// </summary>
	public class CourseRepository : BaseRepository<Course, long>, ICourseRepository
	{
		public CourseRepository(DbContext context) : base(context) {
		}
	}
}
