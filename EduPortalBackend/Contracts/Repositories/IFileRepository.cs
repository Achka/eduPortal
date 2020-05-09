using Entities.Models;

namespace Contracts.Repositories
{
	/// <summary>
	/// Contract which defines <see cref="File"/> specific methods
	/// </summary>
	public interface IFileRepository : IRepository<File, long>
	{
	}
}
