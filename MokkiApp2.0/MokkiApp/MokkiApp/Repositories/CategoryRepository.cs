using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
namespace MokkiApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MokkiAppDbContext _context;

        public CategoryRepository(MokkiAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;

        }

        public Task<int> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChangesAsync();
        }
        public async Task<bool> CategoryExistsAsync(string categoryName)
        {
            var formattedName = categoryName.Trim().ToLower();
            return await _context.Categories.AnyAsync(p => p.Name.Trim().ToLower() == formattedName);
        }
    }
}
