using Contracts.Repositories;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="Material"/> specific methods
	/// </summary>
	public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
	{
		public MaterialRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
