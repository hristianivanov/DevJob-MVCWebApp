namespace DevJobSystem.Services.Interfaces
{
	using View_Models.Job;

	public interface IJobService
	{
		Task<IEnumerable<AllJobViewModel>> AllAsync();

		Task CreateAsync(string description, string requirements, decimal salary);

		Task<IEnumerable<AllJobViewModel>> AllJobsByTechnologyAsync(string technology);

		Task<IEnumerable<JobViewModel>> AllByProgrammerState(string state);

		Task<IEnumerable<JobViewModel>> AllBySalaryAsync(decimal min, decimal max);

		Task<bool> DeleteByIdAsync(int id);

		Task UpdateJob(int id,string description, decimal salary, string requirements);
	}
}
