using System.Reflection;

namespace DevJobSystem.Data
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.AspNetCore.Identity;

	using Models;
	
	public class DevJobDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public DbSet<Company> Companies { get; set; } = null!;
		public DbSet<Job> Jobs { get; set; } = null!;
		public DbSet<Programmer> Programmers { get; set; } = null!;
		public DbSet<CompanyProgrammers> CompaniesProgrammers { get; set; } = null!;
		public DbSet<JobApplication> JobApplications { get; set; } = null!;

		public DevJobDbContext(DbContextOptions<DevJobDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<CompanyProgrammers>()
				.HasKey(cp => new { cp.CompanyId, cp.ProgrammerId });

			Assembly configAssembly = Assembly.GetAssembly(typeof(DevJobDbContext)) ??
			                          Assembly.GetExecutingAssembly();

			builder.ApplyConfigurationsFromAssembly(configAssembly);
		}
	}
}