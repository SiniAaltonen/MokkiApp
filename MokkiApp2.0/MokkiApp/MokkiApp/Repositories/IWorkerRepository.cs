using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public interface IWorkerRepository
    {
        Task<List<Worker>> GetAllWorkersAsync();

        Task<Worker> GetWorkerAsync(int id);

        Task<Worker> UpdateWorker(int id, Worker worker);

        Task<Worker> AddWorker(Worker worker);

        Task<Worker> DeleteWorker(int id);
    }
}
