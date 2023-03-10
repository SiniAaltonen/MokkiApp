using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly MokkiAppDbContext _context;
        public WorkerRepository(MokkiAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return await _context.Workers.ToListAsync();
        }
        public async Task<Worker> GetWorkerAsync(int id)
        {
            return await _context.Workers.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Worker> UpdateWorker(int id, Worker worker)
        {
            var theWorker = await _context.Workers.FirstOrDefaultAsync(i => i.Id == id);
            if (theWorker == null)
            {
                throw new Exception("Worker not found");
            }
            theWorker.FirstName = worker.FirstName;
            theWorker.LastName = worker.LastName;
            theWorker.Phone = worker.Phone;
            theWorker.Email = worker.Email;
            theWorker.Address = worker.Address;
            theWorker.Zipcode = worker.Zipcode;
            theWorker.City = worker.City;
            await _context.SaveChangesAsync();
            return theWorker;
        }

        public async Task<Worker> AddWorker(Worker worker)
        {
            await _context.Workers.AddAsync(worker);
            await _context.SaveChangesAsync();
            return worker;
        }

        public async Task<Worker> DeleteWorker(int id)
        {
            var theWorker = await _context.Workers.FirstOrDefaultAsync(i => i.Id == id);
            if (theWorker == null)
            {
                throw new Exception("Worker not found");
            }
            _context.Workers.Remove(theWorker);
            await _context.SaveChangesAsync();
            return theWorker;
        }

    }
}
