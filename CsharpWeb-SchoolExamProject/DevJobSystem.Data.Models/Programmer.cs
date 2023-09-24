namespace DevJobSystem.Data.Models
{
	
	public class Programmer
	{
        public Programmer()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int Experience { get; set; }

        public string Skill { get; set; } = null!;

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }
	}
}
