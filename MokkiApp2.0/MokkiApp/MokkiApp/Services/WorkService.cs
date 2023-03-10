using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;

namespace MokkiApp.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;

        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository ?? throw new ArgumentNullException(nameof(workRepository));
        }
        public async Task<List<Work>> GetAllWorksAsync()
        {
            return await _workRepository.GetAllWorksAsync();
        }
        public async Task<Work> GetWorkAsync(int id)
        {
            var work = await _workRepository.GetWorkAsync(id);
            return work;
        }

        public async Task<Work> UpdateWork(int id, Work work)
        {
            var theWork = await _workRepository.UpdateWork(id, work);
            return theWork;
        }

        public async Task<Work> AddWork(Work work)
        {
            var theWork = await _workRepository.AddWork(work);
            return theWork;
        }

        public async Task<Work> DeleteWork(int id)
        {
            var theWork = await _workRepository.DeleteWork(id);
            return theWork;
        }
    }
}
