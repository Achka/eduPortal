using Contracts;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess
{
	/// <summary>
	/// Defines <see cref="File"/> specific methods
	/// </summary>
	public class FilesRepository : BaseRepository<File>, IFilesRepository
	{
		public FilesRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
