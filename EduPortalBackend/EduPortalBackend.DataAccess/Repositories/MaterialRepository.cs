using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="Material"/> specific methods
	/// </summary>
	public class MaterialRepository : BaseRepository<Material, long>, IMaterialRepository
	{
		public MaterialRepository(DbContext context) : base(context) {
		}
	}
}
