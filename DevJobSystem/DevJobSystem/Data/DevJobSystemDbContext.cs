namespace DevJobSystem.Data
{
	using System.Reflection;

	using Microsoft.EntityFrameworkCore;

	using Business;
	using Models;

	public class DevJobSystemDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Programmer> Programmers { get; set; } = null!;
        public DbSet<CompanyProgrammers> CompaniesProgrammers { get; set; } = null!;
        public DbSet<JobApplication> JobApplications { get; set; } = null!;

        public DevJobSystemDbContext() { }

		public DevJobSystemDbContext(DbContextOptions<DevJobSystemDbContext> options)
		: base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(AppSettings.DefaultConnection);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CompanyProgrammers>()
				.HasKey(cp => new { cp.CompanyId, cp.ProgrammerId });

			Assembly configAssembly = Assembly.GetAssembly(typeof(DevJobSystemDbContext)) ??
									  Assembly.GetExecutingAssembly();

			modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);
		}
	}
}
