namespace DevJobSystem.Data.Models
{
	using Enum;
	using System.ComponentModel.DataAnnotations.Schema;

	public class JobApplication
	{
		public Guid Id { get; set; }

		public string CandidateName { get; set; } = null!;

		public string CandidateSkills { get; set; } = null!;

		public string CoverLetter { get; set; } = null!;

		public DateTime MeetingDate { get; set; }

		public DateTime SubmissionDate { get; set; }

		public RequestStatus RequestStatus { get; set; }

		[ForeignKey(nameof(Job))]
        public int JobId { get; set; }

		public Job Job { get; set; } = null!;
	}
}
