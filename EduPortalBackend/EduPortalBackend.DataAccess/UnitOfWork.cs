using Contracts;
using EduPortalBackend.DataAccess;

namespace DataAccess
{
	/// <summary>
	/// Entry point for interacting with repositories using shared database context
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext context;
		private IUsersRepository usersRepository;
		private ICoursesRepository coursesRepository;
		private IHomeworksRepository homeworksRepository;
		private IFilesRepository filesRepository;
		private IMaterialsRepository materialsRepository;

		public UnitOfWork(ApplicationDbContext context) => this.context = context;

		public IUsersRepository Users => this.usersRepository ?? (this.usersRepository = new UsersRepository(this.context));

		public ICoursesRepository Courses =>  this.coursesRepository ?? (this.coursesRepository = new CoursesRepository(this.context));

		public IHomeworksRepository Homeworks => 
			this.homeworksRepository ?? (this.homeworksRepository = new HomeworksRepository(this.context));

		public IFilesRepository Files => this.filesRepository ?? (this.filesRepository = new FilesRepository(this.context));

		public IMaterialsRepository Materials => 
			this.materialsRepository ?? (this.materialsRepository = new MaterialsRepository(this.context));

		public void Save() {
			this.context.SaveChanges();
		}
	}


}
