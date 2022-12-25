using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entities;

namespace NLayerApp.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int categoryId);
    }
}
