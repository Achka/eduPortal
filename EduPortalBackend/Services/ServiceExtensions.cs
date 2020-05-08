using Contracts;
using DataAccess;
using EduPortalBackend.DataAccess;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Services
{
	public static class ServiceExtensions {
		public static void ConfigureUnitOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();

		public static void ConfigureIdentity(this IServiceCollection services) =>
			services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

		public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration) {
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
			services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options => {
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidIssuer = configuration["JwtIssuer"],
					ValidAudience = configuration["JwtAudience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});
		}

		public static void ConfigureDbContext(this IServiceCollection services) => services.AddDbContext<ApplicationDbContext>();

		public static void ConfigureServices(this IServiceCollection services) {
			services.AddTransient<AuthService>();
		}
	}
}
