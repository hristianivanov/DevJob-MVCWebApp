namespace DevJobSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class JobEntityConfiguration : IEntityTypeConfiguration<Job>
	{
		public void Configure(EntityTypeBuilder<Job> builder)
		{
			builder.HasData(this.GenerateJobs());
		}

		private ICollection<Job> GenerateJobs()
		{
			var jobs = new HashSet<Job>();

			jobs.Add(new Job()
			{
				Id = 1,
				Description = "Full Stack Developer",
				Requirements = "Experience with JavaScript, React, and Node.js",
				PublishedDate = new DateTime(2022, 02, 15),
				ExpireDate = new DateTime(2022, 03, 15),
			});

			jobs.Add(new Job()
			{
				Id = 2,
				Description = "Software Engineer",
				Requirements = "Proficiency in Python and Django",
				PublishedDate = new DateTime(2022, 03, 10),
				ExpireDate = new DateTime(2022, 04, 10),
			});

			jobs.Add(new Job()
			{
				Id = 3,
				Description = "Data Analyst",
				Requirements = "Strong analytical skills and knowledge of SQL",
				PublishedDate = new DateTime(2022, 04, 05),
				ExpireDate = new DateTime(2022, 05, 05),
			});

			jobs.Add(new Job()
			{
				Id = 4,
				Description = "Frontend Developer",
				Requirements = "Familiarity with HTML, CSS, and JavaScript frameworks",
				PublishedDate = new DateTime(2022, 05, 01),
				ExpireDate = new DateTime(2022, 06, 01),
			});

			jobs.Add(new Job()
			{
				Id = 5,
				Description = "UI/UX Designer",
				Requirements = "Creative design skills and proficiency in design tools",
				PublishedDate = new DateTime(2022, 06, 10),
				ExpireDate = new DateTime(2022, 07, 10),
			});

			return jobs;
		}
	}
}
