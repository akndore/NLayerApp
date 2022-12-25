using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Repositories;

namespace NLayerApp.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithProducts(int categoryId)
        {
            var categories = await _context.Categories
                .Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == categoryId);
            return categories;
        }
    }
}
