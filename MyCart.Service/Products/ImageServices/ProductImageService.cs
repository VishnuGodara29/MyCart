using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCarData;
namespace MyCart.Service.Products.ImageServices;

public class ProductImageService : IProductImageService
{
    private readonly DataContext _context;


    public ProductImageService(DataContext context)
    {
        _context = context;
    }

    public Task<string> AddImageAsync(int productId, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveImageAsync(int productId, int imageId)
    {
        var product = await _context.Products.AnyAsync(x => x.Id == productId);
        if (product == null)
        {
            return false;
        }
        var productImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == imageId);
        if (productImage == null)
        {
            return false;
        }
        _context.ProductImages.Remove(productImage);
        _context.SaveChanges();
        return true;

    }
}

