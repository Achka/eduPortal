using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class AuthService
	{
		private readonly IUnitOfWork db;
		private readonly IConfiguration configuration;
		private readonly UserManager<User> userManager;

		public AuthService(IUnitOfWork db, IConfiguration configuration, UserManager<User> userManager) => 
			(this.db, this.configuration, this.userManager) = (db, configuration.GetSection("Auth"), userManager);

		public async Task<string> GenerateJwtAccessToken(User user) {
			var claims = new List<Claim> {
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Role, (await this.userManager.GetRolesAsync(user)).SingleOrDefault())
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JwtKey"]));
			var token = new JwtSecurityToken(
				issuer: this.configuration["JwtIssuer"],
				audience: this.configuration["JwtAudience"],
				claims: claims,
				expires: DateTime.UtcNow.AddHours(Convert.ToDouble(this.configuration["JwtAccessTokenExpireHours"])),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public string GenerateRefreshToken(User user) {
			var refreshToken = this.db.RefreshTokens.GetAll(token => token.UserId == user.Id).SingleOrDefault();
			if (refreshToken != null) {
				this.db.RefreshTokens.Delete(refreshToken);
			}

			var newRefreshToken = new RefreshToken {
				UserId = user.Id,
				Token = Guid.NewGuid().ToString(),
				Issued = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(this.configuration["RefreshTokenExpireHours"]))
			};
			this.db.RefreshTokens.Create(newRefreshToken);
			this.db.Save();
			return newRefreshToken.Token;
		}
	}
}
