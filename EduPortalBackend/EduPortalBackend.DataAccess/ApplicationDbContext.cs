using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

		private readonly IConfiguration configuration;

		public ApplicationDbContext(IConfiguration configuration) => this.configuration = configuration;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("Azure")).UseLazyLoadingProxies();
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

			var adminName = RoleNames.Admin.ToString();
			var professorName = RoleNames.Professor.ToString();
			var studentName = RoleNames.Student.ToString();
			modelBuilder.Entity<Role>().HasData(
				new Role { Id = 1, Name = adminName.ToLower(), NormalizedName = adminName.ToUpper()},
				new Role { Id = 2, Name = professorName.ToLower(), NormalizedName = professorName.ToUpper() },
				new Role { Id = 3, Name = studentName.ToLower(), NormalizedName = studentName.ToUpper() }
			);

			this.SeedSuperAdmin(modelBuilder);
			// Contacts which should be added(many-to-many)
			//modelBuilder.Entity<Contact>().HasKey(contact => new { contact.UserB, contact.UserBId });
			//modelBuilder.Entity<Contact>().HasOne(contact => contact.UserA)
			//	.WithMany(user => user.Contacts).HasForeignKey(contact => contact.UserAId);
			//modelBuilder.Entity<Contact>().HasOne(contact => contact.UserB)
			//	.WithMany(user => user.Contacts).HasForeignKey(contact => contact.UserBId);
		}

		private void SeedSuperAdmin(ModelBuilder modelBuilder) {
			var superAdminUser = new User {
				Id = 1,
				FirstName = "Super",
				LastName = "Admin",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				UserName = "admin@gmail.com",
				NormalizedUserName = "ADMIN@GMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<User>().HashPassword(null, "Aa1111!!"),
				SecurityStamp = string.Empty
			};
			modelBuilder.Entity<User>().HasData(superAdminUser);
			modelBuilder.Entity<IdentityUserRole<long>>().HasData(new IdentityUserRole<long> {
				RoleId = 1,
				UserId = 1
			});
		}
	}
}
