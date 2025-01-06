using Microsoft.AspNetCore.Http;

namespace MyCart.Service.Products.ImageServices
{

    public interface IProductImageService
    {
        Task<string> AddImageAsync(int productId, IFormFile file);
        Task<bool> RemoveImageAsync(int productId, Guid imageId);
    }

}
