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
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }




       

       
    }
}
