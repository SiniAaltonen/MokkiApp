using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;
using NuGet.Protocol.Core.Types;

namespace MokkiApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        public async Task<Category> AddCategory(Category category)
        {
            var theCategory = await _categoryRepository.GetAllAsync();
            if (theCategory == null)
            {
                Category category1 = new Category();
                category.Name= category1.Name;

                await _categoryRepository.AddCategory(category1);

                return category1;
            }
            throw new Exception("Priduct exists");
        }

        public async Task<List<Category>> GetAllAsync()
        {
           return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return category;
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var theCategory = await _categoryRepository.GetAsync(id);

            if (category != null)
            {
                
                if (categories.Count(p => p.Name == category.Name) > 1) throw new ArgumentException(nameof(category.Name));
                await _categoryRepository.UpdateCategory(theCategory);
                return theCategory;
            }
            throw new ArgumentException(nameof(id));
        }

        public async Task<int> DeleteCategory(int id)
        {

            var category = await _categoryRepository.GetAsync(id);
            if (category != null)
            {
                _categoryRepository.DeleteCategory(category);
            }
            return id;
        }
    }
}
