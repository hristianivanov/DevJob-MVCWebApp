namespace DevJobSystem.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
	using Interfaces;
	using View_Models.Programmer;

	public class ProgrammerService : IProgrammerService
	{
		private readonly DevJobSystemDbContext dbContext;

		public ProgrammerService(DevJobSystemDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllProgrammersViewModel>> AllAsync()
		{
			var programmers = await this.dbContext
				.Programmers
				.Select(p => new AllProgrammersViewModel()
				{
					FirstName = p.FirstName,
					LastName = p.LastName,
					Salary = p.Salary,
					Skill = p.Skill,
					Experience = p.Experience,
				})
				.ToArrayAsync();

			return programmers;
		}

		public async Task CreateAsync(string firstName, string lastName, int experience, string skill, decimal salary)
		{
			if (string.IsNullOrWhiteSpace(firstName) ||
				string.IsNullOrWhiteSpace(lastName) ||
				string.IsNullOrWhiteSpace(skill) ||
				experience < 0 ||
				salary <= 0)
			{
				throw new ArgumentException();
			}

			Programmer programmer = new Programmer()
			{
				FirstName = firstName,
				LastName = lastName,
				Salary = salary,
				Skill = skill,
				Experience = experience,
			};

			await this.dbContext.Programmers.AddAsync(programmer);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<bool> DeleteById(string id)
		{
			Programmer? programmer = await this.dbContext
				.Programmers
				.FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == id.ToLower());

			if (programmer != null)
			{
				this.dbContext.Programmers.Remove(programmer);
				await this.dbContext.SaveChangesAsync();

				return true;
			}

			return false;
		}
	}
}
