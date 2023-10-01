namespace DevJobSystem.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
	using Interfaces;
	using View_Models.Job;

	using static Common.GeneralApplicationConstants;

	public class JobService : IJobService
	{
		private readonly DevJobSystemDbContext dbContext;

		public JobService(DevJobSystemDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllJobViewModel>> AllAsync()
		{
			var jobs = await this.dbContext
				.Jobs
				.Select(j => new AllJobViewModel
				{
					Description = j.Description,
					Salary = j.Salary,
				})
				.ToArrayAsync();

			return jobs;
		}

		public async Task CreateAsync(string description, string requirements, decimal salary)
		{
			if (string.IsNullOrWhiteSpace(description) ||
				string.IsNullOrWhiteSpace(requirements) ||
				salary <= 0)
			{
				throw new ArgumentException();
			}

			Job job = new Job
			{
				Description = description,
				Requirements = requirements,
				Salary = salary,
				PublishedDate = DateTime.UtcNow,
				ExpireDate = DateTime.UtcNow.AddDays(ExpiringJobOfferDays),
			};

			await this.dbContext.Jobs.AddAsync(job);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<AllJobViewModel>> AllJobsByTechnologyAsync(string technology)
		{
			if (string.IsNullOrWhiteSpace(technology))
			{
				throw new ArgumentNullException(nameof(technology));
			}

			var jobs = await this.dbContext
				.Jobs
				.Where(j => j.Requirements.ToLower().Contains(technology.ToLower()))
				.Select(j => new AllJobViewModel
				{
					Description = j.Description,
					Salary = j.Salary,
				})
				.ToArrayAsync();

			return jobs;
		}

		public async Task<IEnumerable<JobViewModel>> AllByProgrammerState(string state)
		{
			if (string.IsNullOrWhiteSpace(state))
			{
				throw new ArgumentNullException(nameof(state));
			}

			var jobs = await this.dbContext
				.Jobs
				.Where(j => j.Description.Contains(state))
				.Select(j => new JobViewModel
				{
					Description = j.Description,
					Requirements = j.Requirements,
					Salary = j.Salary,
				})
				.ToArrayAsync();

			return jobs;
		}

		public async Task<IEnumerable<JobViewModel>> AllBySalaryAsync(decimal min, decimal max)
		{
			if (min > max ||
				max < min ||
				min < 0)
			{
				throw new ArgumentException();
			}

			var jobs = await this.dbContext
				.Jobs
				.Where(j => j.Salary <= max && j.Salary >= min)
				.Select(j => new JobViewModel
				{
					Description = j.Description,
					Requirements = j.Requirements,
					Salary = j.Salary,
				})
				.ToArrayAsync();

			return jobs;
		}

		public async Task<bool> DeleteByIdAsync(int id)
		{
			Job? job = await this.dbContext
				.Jobs
				.FindAsync(id);

			if (job != null)
			{
				this.dbContext.Jobs.Remove(job);
				await this.dbContext.SaveChangesAsync();

				return true;
			}

			return false;
		}

		public async Task UpdateJob(int id, string description, decimal salary, string requirements)
		{
			var job = await this.dbContext
				.Jobs
				.FindAsync(id);

			if (job != null)
			{
				job.Description = description;
				job.Salary = salary;
				job.Requirements = requirements;

				await this.dbContext.SaveChangesAsync();
			}
		}
	}
}
