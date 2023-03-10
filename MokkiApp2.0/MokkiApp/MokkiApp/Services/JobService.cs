using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;

namespace MokkiApp.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }
        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllJobsAsync();
        }
        public async Task<Job> GetJobAsync(int id)
        {
            var job = await _jobRepository.GetJobAsync(id);
            return job;
        }
        public async Task<Job> UpdateJob(int id, Job job)
        {
            var jobs = await _jobRepository.GetAllJobsAsync();
            var theJob = await _jobRepository.GetJobAsync(id);

            if (job != null)
            {

                if (jobs.Count(p => p.Name == job.Name) > 1) throw new ArgumentException(nameof(job.Name));
                await _jobRepository.UpdateJob(theJob);
                return theJob;
            }
            throw new ArgumentException(nameof(id));
        }
        public async Task<Job> AddJob(Job job)
        {
            var theJob = await _jobRepository.GetAllJobsAsync();
            if (!await _jobRepository.JobExistsAsync(job.Name))
            {
                Job job1 = new Job();
                job.Name = job1.Name;
                job.Description = job1.Description;

                await _jobRepository.AddJob(job1);

                return job1;
            }
            throw new Exception("Product exists");
        }
        public async Task<int> DeleteJob(int id)
        {

            var job = await _jobRepository.GetJobAsync(id);
            if (job != null)
            {
                _jobRepository.DeleteJob(job);
            }
            return id;
        }
    }
}
