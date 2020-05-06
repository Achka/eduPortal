using Contracts;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess
{
	/// <summary>
	/// Defines <see cref="Course"/> specific methods
	/// </summary>
	public class CoursesRepository : BaseRepository<Course>, ICoursesRepository
	{
		public CoursesRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
