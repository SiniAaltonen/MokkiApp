using MokkiApp.Models;
namespace MokkiApp.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category> GetAsync(int id);

        Task <int> AddCategory(Category category);

        Task <int> UpdateCategory(Category category);

        Task<int> DeleteCategory(Category category);
    }
}
