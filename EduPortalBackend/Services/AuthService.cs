using Contracts;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services
{
	public class AuthService
	{
		private readonly IUnitOfWork db;
		private readonly IConfiguration configuration;

		public AuthService(IUnitOfWork db, IConfiguration configuration) => 
			(this.db, this.configuration) = (db, configuration.GetSection("Auth"));

		public string GenerateJwtAccessToken(User user) {
			var claims = new List<Claim> {
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
