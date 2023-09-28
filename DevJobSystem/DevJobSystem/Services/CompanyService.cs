namespace DevJobSystem.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Interfaces;
	using View_Models.Company;

	public class CompanyService : ICompanyService
	{
		private readonly DevJobSystemDbContext dbContext;

		public CompanyService(DevJobSystemDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllCompanyViewModel>> AllAsync()
		{
			var companies = await this.dbContext
				.Companies
				.Select(c => new AllCompanyViewModel
				{
					Name = c.Name,
				})
				.ToArrayAsync();

			return companies;
		}

		public async Task<bool> ExistByIdAsync(string id)
		{
			bool result = await this.dbContext
				.Companies
				//.Where(c => c.IsActive)
				.AnyAsync(c => c.Id.ToString() == id);

			return result;
		}
	}
}
