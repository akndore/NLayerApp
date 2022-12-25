using NLayerApp.Core.DTOs;

namespace NLayerApp.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public ProductApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration["BaseUrl"];
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
        {
            var response =
                await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>(new Uri(_baseUrl + "Products/GetProductsWithCategory"));

            return response.Data;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var response =
                await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>(new Uri(_baseUrl + $"Products/{id}"));

            return response.Data;
        }

        public async Task<ProductDto> Save(ProductDto product)
        {
            var response =await _httpClient.PostAsJsonAsync("products",product);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();
            return responseBody.Data;
        }

        public async Task<bool> Update(ProductDto product)
        {
            var response = await _httpClient.PutAsJsonAsync("products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            return response.IsSuccessStatusCode;
        }

      
    }
}
