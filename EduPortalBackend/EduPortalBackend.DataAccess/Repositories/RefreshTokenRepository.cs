using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class RefreshTokenRepository : BaseRepository<RefreshToken, long>, IRefreshTokenRepository
	{
		public RefreshTokenRepository(DbContext context) : base(context) {
		}
	}
}
