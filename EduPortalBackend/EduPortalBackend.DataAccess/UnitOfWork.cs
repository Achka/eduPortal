using Contracts;
using Contracts.Repositories;
using DataAccess.Repositories;
using EduPortalBackend.DataAccess;

namespace DataAccess
{
	/// <summary>
	/// Entry point for interacting with repositories using shared database context
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext context;
		private IUserRepository userRepository;
		private ICourseRepository courseRepository;
		private IHomeworkRepository homeworkRepository;
		private IFileRepository fileRepository;
		private IMaterialRepository materialRepository;
		private IRefreshTokenRepository refreshTokenRepository;

		public UnitOfWork(ApplicationDbContext context) => this.context = context;

		public IUserRepository Users => this.userRepository ?? (this.userRepository = new UserRepository(this.context));

		public ICourseRepository Courses =>  this.courseRepository ?? (this.courseRepository = new CourseRepository(this.context));

		public IHomeworkRepository Homeworks => 
			this.homeworkRepository ?? (this.homeworkRepository = new HomeworkRepository(this.context));

		public IFileRepository Files => this.fileRepository ?? (this.fileRepository = new FileRepository(this.context));

		public IMaterialRepository Materials => 
			this.materialRepository ?? (this.materialRepository = new MaterialRepository(this.context));

		public IRefreshTokenRepository RefreshTokens =>
			this.refreshTokenRepository ?? (this.refreshTokenRepository = new RefreshTokenRepository(this.context));

		public void Save() {
			this.context.SaveChanges();
		}
	}
}
