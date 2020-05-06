namespace Contracts
{
	/// <summary>
	/// Contract which defines an entry point for interacting with repositories
	/// </summary>
	public interface IUnitOfWork
	{
		IUsersRepository Users { get; }
		ICoursesRepository Courses { get; }
		IHomeworksRepository Homeworks { get; }
		IFilesRepository Files { get; }
		IMaterialsRepository Materials { get; }

		// And others if needed

		void Save();
	}
}
