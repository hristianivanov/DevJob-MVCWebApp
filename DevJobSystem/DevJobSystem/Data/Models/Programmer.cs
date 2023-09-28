namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Programmer;

	public class Programmer
	{
        public Programmer()
        {
            this.Id = Guid.NewGuid();
            this.CompanyProgrammers = new HashSet<CompanyProgrammers>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public int Experience { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Skill { get; set; } = null!;

		public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public ICollection<CompanyProgrammers> CompanyProgrammers { get; set; }
    }
}
