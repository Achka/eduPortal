using Contracts.Repositories;
using EduPortalBackend.DataAccess;
using Entities.Models;

namespace DataAccess.Repositories
{
	public class RefreshTokenRepository : BaseRepository<RefreshToken, long>, IRefreshTokenRepository
	{
		public RefreshTokenRepository(ApplicationDbContext context) : base(context) {
		}
	}
}
