namespace DevJobSystem.Data
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.AspNetCore.Identity;

	using Models;

	public class DevJobDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public DevJobDbContext(DbContextOptions<DevJobDbContext> options)
			: base(options)
		{
		}
	}
}