namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Company
	{
        public Company()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string Address { get; set; } = null!;

        public int ProgrammersCount { get; set; }

        public decimal AvgSalary { get; set; }
    }
}
