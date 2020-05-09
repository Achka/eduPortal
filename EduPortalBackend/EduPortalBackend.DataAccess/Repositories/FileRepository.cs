using Contracts.Repositories;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="File"/> specific methods
	/// </summary>
	public class FileRepository : BaseRepository<File>, IFileRepository
	{
		public FileRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
