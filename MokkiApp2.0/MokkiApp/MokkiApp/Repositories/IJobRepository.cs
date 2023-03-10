using MokkiApp.Models;
namespace MokkiApp.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobsAsync();

        Task<Job> GetJobAsync(int id);

        Task<int> UpdateJob(Job job);

        Task<int> AddJob(Job job);

        Task<int> DeleteJob(Job job);

        Task<bool> JobExistsAsync(string jobName);
    }
}
