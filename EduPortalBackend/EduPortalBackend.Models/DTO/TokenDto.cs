namespace Entities.DTO
{
	public class TokenDto
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
