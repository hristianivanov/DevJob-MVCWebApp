namespace DevJobSystem.Services.Interfaces
{
	using View_Models.Company;

	public interface ICompanyService
	{
		Task<IEnumerable<AllCompanyViewModel>> AllAsync();

		Task<bool> ExistByIdAsync(string id);
	}
}
