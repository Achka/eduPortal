using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="File"/> specific methods
	/// </summary>
	public class FileRepository : BaseRepository<File, long>, IFileRepository
	{
		public FileRepository(DbContext context) : base(context) {
		}
	}
}
