using Contracts;
using Contracts.Repositories;
using DataAccess.Repositories;
using EduPortalBackend.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	/// <summary>
	/// Entry point for interacting with repositories using shared database context
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private IUserRepository userRepository;
		private ICourseRepository courseRepository;
		private IHomeworkRepository homeworkRepository;
		private IFileRepository fileRepository;
		private IMaterialRepository materialRepository;
		private IRefreshTokenRepository refreshTokenRepository;

		public DbContext Context { get; }

		public UnitOfWork(ApplicationDbContext context) => this.Context = context;

		public IUserRepository Users => this.userRepository ?? (this.userRepository = new UserRepository(this.Context));

		public ICourseRepository Courses =>  this.courseRepository ?? (this.courseRepository = new CourseRepository(this.Context));

		public IHomeworkRepository Homeworks => 
			this.homeworkRepository ?? (this.homeworkRepository = new HomeworkRepository(this.Context));

		public IFileRepository Files => this.fileRepository ?? (this.fileRepository = new FileRepository(this.Context));

		public IMaterialRepository Materials => 
			this.materialRepository ?? (this.materialRepository = new MaterialRepository(this.Context));

		public IRefreshTokenRepository RefreshTokens =>
			this.refreshTokenRepository ?? (this.refreshTokenRepository = new RefreshTokenRepository(this.Context));

		public void Save() {
			this.Context.SaveChanges();
		}
	}
}
