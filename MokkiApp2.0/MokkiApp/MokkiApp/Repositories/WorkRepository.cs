using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly MokkiAppDbContext _context;
        public WorkRepository(MokkiAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Work>> GetAllWorksAsync()
        {
            return await _context.Works.ToListAsync();
        }
        public async Task<Work> GetWorkAsync(int id)
        {
            return await _context.Works.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Work> UpdateWork(int id, Work work)
        {
            var theWork = await _context.Works.FirstOrDefaultAsync(i => i.Id == id);
            if (theWork == null)
            {
                throw new Exception("Work not found");
            }
            theWork.Duration = work.Duration;
            theWork.WorkName = work.WorkName;
            theWork.Importancy = work.Importancy;
            theWork.Equipment = work.Equipment;
            await _context.SaveChangesAsync();
            return theWork;
        }

        public async Task<Work> AddWork(Work work)
        {
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();
            return work;
        }

        public async Task<Work> DeleteWork(int id)
        {
            var theWork = await _context.Works.FirstOrDefaultAsync(i => i.Id == id);
            if (theWork == null)
            {
                throw new Exception("Work not found");
            }
            _context.Works.Remove(theWork);
            await _context.SaveChangesAsync();
            return theWork;
        }
    }
}
