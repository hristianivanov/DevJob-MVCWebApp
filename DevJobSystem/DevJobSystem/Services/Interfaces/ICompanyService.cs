namespace DevJobSystem.Services.Interfaces
{
	public interface ICompanyService
	{
		Task<IEnumerable<AllCompanyViewModel>> AllAsync();


	}
}
