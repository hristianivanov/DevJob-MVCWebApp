namespace DevJobSystem.Services.Interfaces
{
	using View_Models.Company;

	public interface ICompanyService
	{
		Task<IEnumerable<AllCompanyViewModel>> AllAsync();

		Task<bool> ExistByIdAsync(string id);

		Task<int> HiredProgrammersCountByCompanyIdAsync(string id);

		Task<string> CreateAndReturnIdAsync(string name, string address);

		Task CreateAsync(string name, string address);

		Task<CompanyViewModel?> GetCompanyByAddressAsync(string address);

		Task<IEnumerable<AllCompanyViewModel>> GetCompaniesByMaxProgrammersCountAsync(int maxProgrammers);

		Task<bool> DeleteByNameAsync(string name);

		Task HireProgrammer(string companyId, string programmerId);
	}
}
