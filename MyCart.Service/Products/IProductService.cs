using MyCart.Domain.Products;
using MyCart.Repository.Products.Dtos;
using MyCart.Service.Dtos;

namespace MyCart.Service.Products
{
    public interface IProductService
    {

        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);
        Task<bool> CreateProductAsync(CreateProductDto productDto);
        Task<ProductDTO> UpdateProductAsync(int id, ProductDTO productDto);
        Task DeleteProductAsync(int id);
        Task<List<ProductDTO>> SearchProductAsync(SearchProductDto searchProductDto);
    }
}
