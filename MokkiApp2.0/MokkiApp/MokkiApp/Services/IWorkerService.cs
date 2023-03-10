using MokkiApp.Models;

namespace MokkiApp.Services
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetAllWorkersAsync();

        Task<Worker> GetWorkerAsync(int id);

        Task<Worker> UpdateWorker(int id, Worker worker);

        Task<Worker> AddWorker(Worker worker);

        Task<Worker> DeleteWorker(int id);
    }
}
