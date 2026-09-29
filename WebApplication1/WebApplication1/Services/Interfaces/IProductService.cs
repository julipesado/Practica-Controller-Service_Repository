using WebApplication1.Models.DTOs.Requests;
using WebApplication1.Models.DTOs.Responses;

namespace WebApplication1.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductForReadDto> GetAllProducts();
        ProductForReadDto? GetProductById(int id);
        ProductForReadDto CreateProduct(ProductForCreateDto dto);
        void UpdateProduct(int id, ProductForUpdateDto dto);
        void DeleteProduct(int id);
        List<ProductForReadDto> SearchProductsByName(string name);
        ProductStatsDto GetStats();
    }
}