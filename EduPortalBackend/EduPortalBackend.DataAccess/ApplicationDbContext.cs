using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduPortalBackend.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext<User, Role, long> {
		// Contacts which should be added
		//public DbSet<Contact> Contacts { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Material> Materials { get; set; }
		public DbSet<File> Files { get; set; }
		public DbSet<Homework> Homeworks { get; set; }
		public DbSet<Estimate> Estimates { get; set; }
		public DbSet<UserCourse> UserCourses { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			// environment dependant connection string must be here instead of hardcoded local db one
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EduPortalDb;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<Role>().ToTable("Roles");
			modelBuilder.Entity<IdentityUserRole<long>>().ToTable("UserRoles");

			modelBuilder.Entity<UserCourse>().HasKey(userCourse => new { userCourse.CourseId, userCourse.UserId });
			modelBuilder.Entity<UserCourse>().HasOne(userCourse => userCourse.User).WithMany(user => user.UserCourses)
				.HasForeignKey(userCourse => userCourse.UserId);
			modelBuilder.Entity<UserCourse>().HasOne(userCourse => userCourse.Course).WithMany(course => course.UserCourses)
				.HasForeignKey(userCourse => userCourse.CourseId);

			// Contacts which should be added(many-to-many)
			//modelBuilder.Entity<Contact>().HasKey(contact => new { contact.UserB, contact.UserBId });
			//modelBuilder.Entity<Contact>().HasOne(contact => contact.UserA)
			//	.WithMany(user => user.Contacts).HasForeignKey(contact => contact.UserAId);
			//modelBuilder.Entity<Contact>().HasOne(contact => contact.UserB)
			//	.WithMany(user => user.Contacts).HasForeignKey(contact => contact.UserBId);
		}
	}
}
