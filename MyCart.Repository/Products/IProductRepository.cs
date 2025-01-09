using MyCart.Domain.Products;
using MyCart.Repository.GenericRepository;
using MyCart.Repository.Products.Dtos;

namespace MyCart.Repository.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<IEnumerable<Product>> SearchProductAsync(SearchProductDto searchProductDto);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<bool>UploadProductImage(int productId, string imagePath);
        Task<bool> RemoveImageAsync(int productId, int imageId);


    }
}
