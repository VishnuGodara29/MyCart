using MyCart.Domain.Products;

namespace MyCart.Repository.Products.Images
{
    public interface IProductImageRepository
    {
        Task AddProductImageAsync(ProductImages productImage);
        Task<IEnumerable<ProductImages>> GetImagesByProductIdAsync(int productId);
    }

}
