using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="Homework"/> specific methods
	/// </summary>
	public class HomeworkRepository : BaseRepository<Homework, long>, IHomeworkRepository
	{
		public HomeworkRepository(DbContext context) : base(context) {
		}
	}
}
