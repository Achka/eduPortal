using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class RefreshToken
	{
		public long Id { get; set; }

		[Required]
		public string Token { get; set; }

		public long UserId { get; set; }
		public virtual User User { get; set; }

		public DateTime Issued { get; set; }
		public DateTime Expires { get; set; }
	}
}
