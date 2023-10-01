namespace DevJobSystem.Services.Interfaces
{
	using View_Models.Programmer;

	public interface IProgrammerService
	{
		Task<IEnumerable<AllProgrammersViewModel>> AllAsync();

		Task CreateAsync(string firstName, string lastName, int experience, string skill, decimal salary);

		Task<bool> DeleteById(string id);
	}
}
