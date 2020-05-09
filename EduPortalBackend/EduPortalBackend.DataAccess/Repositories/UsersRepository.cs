using Contracts;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess
{
	/// <summary>
	/// Defines <see cref="User"/> specific methods
	/// </summary>
	public class UsersRepository : BaseRepository<User>, IUsersRepository
	{
		public UsersRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
