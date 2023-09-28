namespace DevJobSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class CompanyProgrammersEntityConfiguration : IEntityTypeConfiguration<CompanyProgrammers>
	{
		public void Configure(EntityTypeBuilder<CompanyProgrammers> builder)
		{
			builder.HasData(this.GenerateCompanyProgrammers());
		}

		private ICollection<CompanyProgrammers> GenerateCompanyProgrammers()
		{
			var companyProgrammers = new HashSet<CompanyProgrammers>();

			companyProgrammers.Add(new CompanyProgrammers()
			{
				CompanyId = Guid.Parse("6edd17b7-8291-4fda-a343-de3ecba2a4e2"),
				ProgrammerId = Guid.Parse("f92eef01-c91b-4be6-975d-80e03edfbd5b"),
			});

			companyProgrammers.Add(new CompanyProgrammers()
			{
				CompanyId = Guid.Parse("3d2e8998-4d57-4541-864e-fd0bf99b7ed3"),
				ProgrammerId = Guid.Parse("16b08a53-8c7f-4112-b109-7ef7c0a919b4"),
			});

			return companyProgrammers;
		}
	}
}
