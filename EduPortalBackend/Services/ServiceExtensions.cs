using Contracts;
using DataAccess;
using EduPortalBackend.DataAccess;
using Entities.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
	public static class ServiceExtensions
	{
		public static void ConfigureUnitOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();

		public static void ConfigureIdentity(this IServiceCollection services) => 
			services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>();

		public static void ConfigureDbContext(this IServiceCollection services) => services.AddDbContext<ApplicationDbContext>();
	}
}
