using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public interface IWorkRepository
    {
        Task<List<Work>> GetAllWorksAsync();

        Task<Work> GetWorkAsync(int id);

        Task<Work> UpdateWork(int id, Work work);

        Task<Work> AddWork(Work work);

        Task<Work> DeleteWork(int id);   
    }
}
