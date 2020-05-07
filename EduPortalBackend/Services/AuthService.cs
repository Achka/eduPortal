using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class AuthService
	{
		private readonly IConfiguration configuration;

		public AuthService(IConfiguration configuration) => this.configuration = configuration;

		public string GenerateJwtToken(User user) {
			var claims = new List<Claim> {
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JwtKey"]));
			var token = new JwtSecurityToken(
				issuer: this.configuration["JwtIssuer"],
				audience: this.configuration["JwtAudience"],
				claims: claims,
				expires: DateTime.UtcNow.AddDays(Convert.ToDouble(this.configuration["JwtExpireDays"])),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
