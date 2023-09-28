namespace DevJobSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class ProgrammerEntityConfiguration : IEntityTypeConfiguration<Programmer>
	{
		public void Configure(EntityTypeBuilder<Programmer> builder)
		{
			builder
				.Property(p => p.Salary)
				.HasPrecision(18, 2);

			builder.HasData(this.GenerateProgrammers());
		}

		private ICollection<Programmer> GenerateProgrammers()
		{
			var programmers = new HashSet<Programmer>();

			programmers.Add(new Programmer()
			{
				Id = Guid.Parse("f1421d2a-808f-4ce2-ad21-9ecd86150483"),
				FirstName = "John",
				LastName = "Doe",
				Experience = 5,
				Skill = "C#, ASP.NET Core",
				Salary = 80000.00m,
				HireDate = new DateTime(2022, 03, 15),
			});

			programmers.Add(new Programmer()
			{
				Id = Guid.Parse("006a5812-e531-4c6a-815a-215e61595cec"),
				FirstName = "Alice",
				LastName = "Smith",
				Experience = 3,
				Skill = "JavaScript, React",
				Salary = 70000.00m,
				HireDate = new DateTime(2022, 06, 20),
			});

			programmers.Add(new Programmer()
			{
				Id = Guid.Parse("db412b5c-100f-49f3-8ff9-963caee38c2a"),
				FirstName = "Michael",
				LastName = "Johnson",
				Experience = 7,
				Skill = "Java, Spring Boot",
				Salary = 90000.00m,
				HireDate = new DateTime(2021, 12, 10),
			});

			programmers.Add(new Programmer()
			{
				Id = Guid.Parse("16b08a53-8c7f-4112-b109-7ef7c0a919b4"),
				FirstName = "Emily",
				LastName = "Brown",
				Experience = 2,
				Skill = "Python, Django",
				Salary = 65000.00m,
				HireDate = new DateTime(2023, 01, 25),
			});

			programmers.Add(new Programmer()
			{
				Id = Guid.Parse("f92eef01-c91b-4be6-975d-80e03edfbd5b"),
				FirstName = "Robert",
				LastName = "Garcia",
				Experience = 6,
				Skill = "Ruby on Rails",
				Salary = 85000.00m,
				HireDate = new DateTime(2022, 08, 05),
			});

			return programmers;
		}
	}
}
