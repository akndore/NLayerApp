using AutoMapper;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using System.Net;

namespace NLayerApp.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProducts(categoryId);
            var categoryDto = _mapper.Map<Category, CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(HttpStatusCode.Accepted, categoryDto);
        }
    }
}
