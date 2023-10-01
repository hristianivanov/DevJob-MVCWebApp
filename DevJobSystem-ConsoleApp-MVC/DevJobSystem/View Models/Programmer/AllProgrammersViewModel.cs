namespace DevJobSystem.View_Models.Programmer
{
	public class AllProgrammersViewModel
	{
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;
        public string Skill { get; set; } = null!;

        public int Experience { get; set; }

        public decimal Salary { get; set; }
	}
}
