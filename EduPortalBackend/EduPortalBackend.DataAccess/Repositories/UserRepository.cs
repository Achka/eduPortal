using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	/// <summary>
	/// Defines <see cref="User"/> specific methods
	/// </summary>
	public class UserRepository : BaseRepository<User, long>, IUserRepository
	{
		public UserRepository(DbContext context) : base(context) {
		}
	}
}
