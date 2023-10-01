namespace DevJobSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Job
	{
        public Job()
        {
            this.JobApplications = new HashSet<JobApplication>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(int.MaxValue)]
        public string Requirements { get; set; } = null!;

        public decimal Salary { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }
	}
}
