namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class CompanyProgrammers
	{
		[ForeignKey(nameof(Company))]
		public Guid CompanyId { get; set; }
		public virtual Company Company { get; set; } = null!;

		[ForeignKey(nameof(Programmer))]
		public Guid ProgrammerId { get; set; }
		public virtual Programmer Programmer { get; set; } = null!;
	}
}
