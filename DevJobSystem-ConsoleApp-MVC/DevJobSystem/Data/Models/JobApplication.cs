namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Enum;

	using static Common.EntityValidationConstants.JobApplication;

	public class JobApplication
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(CandidateNameMaxLength)]
		public string CandidateName { get; set; } = null!;

		[Required]
		[MaxLength(int.MaxValue)]
		public string CandidateSkills { get; set; } = null!;

		[Required]
		[MaxLength(int.MaxValue)]
		public string CoverLetter { get; set; } = null!;

		public DateTime MeetingDate { get; set; }

		public DateTime SubmissionDate { get; set; }

		public RequestStatus RequestStatus { get; set; }

		[ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

		[ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
	}
}
