using Contracts;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess
{
	/// <summary>
	/// Defines <see cref="Homework"/> specific methods
	/// </summary>
	public class HomeworksRepository : BaseRepository<Homework>, IHomeworksRepository
	{
		public HomeworksRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
