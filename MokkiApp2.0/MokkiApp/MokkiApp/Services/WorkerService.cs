using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;

namespace MokkiApp.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository ?? throw new ArgumentNullException(nameof(workerRepository));
        }
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            return await _workerRepository.GetAllWorkersAsync();
        }
        public async Task<Worker> GetWorkerAsync(int id)
        {
            var worker = await _workerRepository.GetWorkerAsync(id);
            return worker;
        }

        public async Task<Worker> UpdateWorker(int id, Worker worker)
        {
            var theWorker = await _workerRepository.UpdateWorker(id, worker);
            return theWorker;
        }

        public async Task<Worker> AddWorker(Worker worker)
        {
            var theWorker = await _workerRepository.AddWorker(worker);
            return theWorker;
        }

        public async Task<Worker> DeleteWorker(int id)
        {
            var theWorker = await _workerRepository.DeleteWorker(id);
            return theWorker;
        }
    }
}
