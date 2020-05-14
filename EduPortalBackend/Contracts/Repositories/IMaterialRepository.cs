using Entities.Models;

namespace Contracts.Repositories
{
	/// <summary>
	/// Contract which defines <see cref="Material"/> specific methods
	/// </summary>
	public interface IMaterialRepository : IRepository<Material, long>
	{
	}
}
