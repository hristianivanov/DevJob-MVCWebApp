namespace DevJobSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder
				.Property(c => c.AvgSalary)
				.HasPrecision(18, 2);

			builder.HasData(this.GenerateCompanies());
		}

		private ICollection<Company> GenerateCompanies()
		{
			var companies = new HashSet<Company>();

			companies.Add(new Company()
			{
				Id = Guid.Parse("6edd17b7-8291-4fda-a343-de3ecba2a4e2"),
				Name = "TechCo Inc.",
				Address = "123 Main Street, City",
				ProgrammersCount = 50,
				AvgSalary = 95000.00m,
			});

			companies.Add(new Company()
			{
				Id = Guid.Parse("3d2e8998-4d57-4541-864e-fd0bf99b7ed3"),
				Name = "SoftTech Solutions",
				Address = "456 Elm Avenue, Town",
				ProgrammersCount = 30,
				AvgSalary = 85000.00m,
			});

			companies.Add(new Company()
			{
				Id = Guid.Parse("e5d9fa8d-3163-456e-be6b-07a2e43af378"),
				Name = "DataAnalytics Corp.",
				Address = "789 Oak Road, Village",
				ProgrammersCount = 25,
				AvgSalary = 90000.00m,
			});

			companies.Add(new Company()
			{
				Id = Guid.Parse("a286dc6f-4293-470c-9e64-58c6d029a8b3"),
				Name = "WebDesigners Ltd.",
				Address = "101 Pine Lane, Suburb",
				ProgrammersCount = 40,
				AvgSalary = 80000.00m,
			});

			companies.Add(new Company()
			{
				Id = Guid.Parse("a0ee66ad-cafe-4a97-afc7-3dea62a3a256"),
				Name = "UX Innovations",
				Address = "222 Cedar Street, Metro",
				ProgrammersCount = 20,
				AvgSalary = 92000.00m,
			});

			return companies;
		}
	}
}
