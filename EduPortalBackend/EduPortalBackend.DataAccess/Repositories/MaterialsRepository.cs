using Contracts;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess
{
	/// <summary>
	/// Defines <see cref="Material"/> specific methods
	/// </summary>
	public class MaterialsRepository : BaseRepository<Material>, IMaterialsRepository
	{
		public MaterialsRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
