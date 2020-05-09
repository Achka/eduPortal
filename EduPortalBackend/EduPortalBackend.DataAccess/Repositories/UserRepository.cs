using Contracts.Repositories;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="User"/> specific methods
	/// </summary>
	public class UserRepository : BaseRepository<User, long>, IUserRepository
	{
		public UserRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
