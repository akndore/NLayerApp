using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Repositories;

namespace NLayerApp.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            var products = await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
            return products;
        }
    }
}
