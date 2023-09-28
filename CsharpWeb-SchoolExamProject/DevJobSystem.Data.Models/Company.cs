namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Company;

	public class Company
	{
		public Company()
		{
			this.Id = Guid.NewGuid();
			this.CompanyProgrammers = new HashSet<CompanyProgrammers>();
		}

		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(AddressMaxLength)]
		public string Address { get; set; } = null!;

		public int ProgrammersCount { get; set; }

		public decimal AvgSalary { get; set; }

		public virtual ICollection<CompanyProgrammers> CompanyProgrammers { get; set; }
	}
}
