using Contracts.Repositories;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="Homework"/> specific methods
	/// </summary>
	public class HomeworkRepository : BaseRepository<Homework, long>, IHomeworkRepository
	{
		public HomeworkRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
