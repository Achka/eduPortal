using Contracts.Repositories;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="Course"/> specific methods
	/// </summary>
	public class CourseRepository : BaseRepository<Course>, ICourseRepository
	{
		public CourseRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
