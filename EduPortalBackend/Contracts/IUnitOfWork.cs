using Contracts.Repositories;

namespace Contracts
{
	/// <summary>
	/// Contract which defines an entry point for interacting with repositories
	/// </summary>
	public interface IUnitOfWork {
		IUserRepository Users { get; }
		ICourseRepository Courses { get; }
		IHomeworkRepository Homeworks { get; }
		IFileRepository Files { get; }
		IMaterialRepository Materials { get; }
		IRefreshTokenRepository RefreshTokens { get; }

		// And others if needed

		void Save();
	}
}
