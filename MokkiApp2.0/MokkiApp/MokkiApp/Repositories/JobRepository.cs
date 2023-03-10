using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly MokkiAppDbContext _context;
        public JobRepository(MokkiAppDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobAsync(int id)
        {
            return await _context.Jobs.FirstOrDefaultAsync(i => i.Id == id);
        }
        public Task<int> UpdateJob(Job job)
        {
            _context.Jobs.Update(job);
            return _context.SaveChangesAsync();
        }
        public Task<int> AddJob(Job job)
        {
            _context.Jobs.Add(job);
            return _context.SaveChangesAsync();
        }
        public Task<int> DeleteJob(Job job)
        {
            _context.Jobs.Remove(job);
            return _context.SaveChangesAsync();
        }
        public async Task<bool> JobExistsAsync(string jobName)
        {
            var formattedName = jobName.Trim().ToLower();
            return await _context.Jobs.AnyAsync(p => p.Name.Trim().ToLower() == formattedName);
        }
    }
}
