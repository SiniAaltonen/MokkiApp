using MokkiApp.Models;

namespace MokkiApp.Services
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobsAsync();

        Task<Job> GetJobAsync(int id);

        Task<Job> UpdateJob(int id, Job job);

        Task<Job> AddJob(Job job);

        Task<int> DeleteJob(int id);
    }
}
