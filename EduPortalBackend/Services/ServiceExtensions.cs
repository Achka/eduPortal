using AutoMapper;
using Contracts;
using DataAccess;
using EduPortalBackend.DataAccess;
using Entities.Models;
using Entities.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

		public static void ConfigureServices(this IServiceCollection services) => services.AddTransient<AuthService>();

		public static void ConfigureJsonSerialization(this IMvcBuilder builder) => builder.AddJsonOptions(options => {
			options.JsonSerializerOptions.IgnoreNullValues = true;
		});

		public static void ConfigureSwagger(this IServiceCollection services) => services.AddSwaggerGen(options => {
			options.SwaggerDoc("v1", new OpenApiInfo { Title = "EduPortal API", Version = "v3" });
		});

		public static void UseSwaggerWithUI(this IApplicationBuilder app) {
			app.UseSwagger();
			app.UseSwaggerUI(options => options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Edu Portal API v1"));
		}

		/// <summary>
		/// Add Automapper service and populate it with profiles from parent assembly of UserProfile class
		/// </summary>
		public static void ConfigureAutoMapper(this IServiceCollection services) {
			services.AddAutoMapper(typeof(UserProfile));
		}
	}
}
