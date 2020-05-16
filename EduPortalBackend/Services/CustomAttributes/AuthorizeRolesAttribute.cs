using Microsoft.AspNetCore.Authorization;

namespace Services.CustomAttributes
{
	public sealed class AuthorizeRolesAttribute : AuthorizeAttribute
	{
		public AuthorizeRolesAttribute(params string[] roles) : base() {
			this.Roles = string.Join(",", roles);
		}
	}
}
