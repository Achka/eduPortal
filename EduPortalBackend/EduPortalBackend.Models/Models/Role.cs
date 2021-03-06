﻿using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
	/// <summary>
	/// Needed to allow <see cref="User"/> use <see cref="long"/> primary key
	/// </summary>
	public class Role : IdentityRole<long> 
	{
		public const string ADMIN = "admin";
		public const string PROFESSOR = "professor";
		public const string STUDENT = "student";
	}
}
