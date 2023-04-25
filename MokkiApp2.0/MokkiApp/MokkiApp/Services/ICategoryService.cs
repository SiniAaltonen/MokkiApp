using MokkiApp.Models;
namespace MokkiApp.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();

        Task<Category> GetAsync(int id);

        Task<Category> AddCategory(Category category);

        Task<Category> UpdateCategory(int id, Category category);

        Task<bool> DeleteCategory(int id);
    }
}
