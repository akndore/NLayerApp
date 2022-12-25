using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entities;

namespace NLayerApp.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
    }
}
