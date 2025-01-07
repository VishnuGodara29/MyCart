using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Products;
using MyCart.Repository.GenericRepositorys;
namespace MyCart.Repository.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive)
                .ToListAsync();
        }



        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductAsync(SearchProductDto searchProductDto)
        {
            var query = await _context.Products.Include(x=>x.Category).ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchProductDto.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(searchProductDto.Name.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchProductDto.Description))
            {
                query= query.Where(x=>x.Description.Contains(searchProductDto.Description)).ToList();

            }
            if (searchProductDto.CategoryId.HasValue&&searchProductDto.CategoryId.Value!=0)
            {
                query= query.Where(x=>x.CategoryId==searchProductDto.CategoryId.Value).ToList();
            }
            if (searchProductDto.CreateDate.HasValue)
            {
                query= query.Where(x=>x.CreateDate<=searchProductDto.CreateDate).ToList();
            }
            if(searchProductDto.UpdateDate.HasValue)
            {
                query= query.Where(x => x.UpdateDate >= searchProductDto.UpdateDate).ToList();

            }
            return query;
        }
    }
}
