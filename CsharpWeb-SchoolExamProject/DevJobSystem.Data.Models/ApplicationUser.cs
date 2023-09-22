﻿namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();

		}

		[Required, MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required, MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;
	}
}
