namespace DevJobSystem.Services
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
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

		public async Task<int> HiredProgrammersCountByCompanyIdAsync(string id)
		{
			var count = await this.dbContext
				.JobApplications
				.Where(ja => ja.CompanyId.ToString() == id)
				.CountAsync();

			return count;
		}

		public async Task<string> CreateAndReturnIdAsync(string name, string address)
		{
			if (string.IsNullOrWhiteSpace(name) ||
				string.IsNullOrWhiteSpace(address))
			{
				throw new ArgumentNullException();
			}

			Company company = new Company()
			{
				Name = name,
				Address = address
			};

			await this.dbContext.Companies.AddAsync(company);
			await this.dbContext.SaveChangesAsync();

			return company.Id.ToString();
		}

		public async Task CreateAsync(string name, string address)
		{
			if (string.IsNullOrWhiteSpace(name) ||
				string.IsNullOrWhiteSpace(address))
			{
				throw new ArgumentNullException();
			}

			Company company = new Company()
			{
				Name = name,
				Address = address
			};

			await this.dbContext.Companies.AddAsync(company);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<CompanyViewModel?> GetCompanyByAddressAsync(string address)
		{
			if (string.IsNullOrWhiteSpace(address))
			{
				throw new ArgumentNullException(nameof(address));
			}

			var company = await this.dbContext
				.Companies
				.Where(c => c.Address.Contains(address))
				.Select(c => new CompanyViewModel()
				{
					Name = c.Name,
					Address = c.Address,
					AvgSalary = c.AvgSalary,
				})
				.ToArrayAsync();

			// that's not the right solution I know... It's temporary
			return company.FirstOrDefault();
		}

		public async Task<IEnumerable<AllCompanyViewModel>> GetCompaniesByMaxProgrammersCountAsync(int maxProgrammers)
		{
			if (maxProgrammers <= 0)
			{
				throw new ArgumentException(nameof(maxProgrammers));
			}

			var companies = await this.dbContext
				.Companies
				.Where(c => c.ProgrammersCount <= maxProgrammers)
				.Select(c => new AllCompanyViewModel()
				{
					Name = c.Name
				})
				.ToArrayAsync();

			return companies;
		}

		public async Task<bool> DeleteByNameAsync(string name)
		{
			if (!string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException(nameof(name));
			}

			Company? company = await this.dbContext
				.Companies
				.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

			if (company != null)
			{
				this.dbContext.Companies.Remove(company);
				await this.dbContext.SaveChangesAsync();

				return true;
			}

			return false;
		}

		public async Task HireProgrammer(string companyId, string programmerId)
		{
			var company = await this.dbContext
				.Companies
				.FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == companyId.ToLower());

			var programmer = await this.dbContext
				.Programmers
				.FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == programmerId.ToLower());

			if (company != null)
			{
				if (programmer != null)
				{
					var cp = new CompanyProgrammers()
					{
						CompanyId = Guid.Parse(companyId),
						ProgrammerId = Guid.Parse(programmerId),
					};

					await this.dbContext.CompaniesProgrammers.AddAsync(cp);
					await this.dbContext.SaveChangesAsync();
				}
			}
		}
	}
}
