using Entities.Models;

namespace Contracts.Repositories
{
	/// <summary>
	/// Contract which defines <see cref="Course"/> specific methods
	/// </summary>
	public interface ICourseRepository : IRepository<Course, long>
	{
	}
}
