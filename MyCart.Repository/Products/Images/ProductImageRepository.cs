//using Microsoft.EntityFrameworkCore;
//using MyCart.Domain.Products;

//namespace MyCart.Repository.Products.Images
//{
//    public class ProductImageRepository : IProductImageRepository
//    {
//        private readonly DbContext _context;

//        public ProductImageRepository(DbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddProductImageAsync(ProductImages productImage)
//        {
//            await _context.Set<ProductImages>().AddAsync(productImage);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<IEnumerable<ProductImages>> GetImagesByProductIdAsync(int productId)
//        {
//            return await _context.Set<ProductImages>()
//                .Where(pi => pi.ProductId == productId)
//                .ToListAsync();
//        }
//    }
//}

