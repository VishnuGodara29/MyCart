using MyCart.Domain.Products;
using MyCart.Repository.GenericRepository;

namespace MyCart.Repository.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<IEnumerable<Product>> SearchProductAsync(SearchProductDto searchProductDto);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        
    }
}
