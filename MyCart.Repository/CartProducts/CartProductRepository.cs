using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Carts;
using MyCart.Repository.GenericRepositorys;

namespace MyCart.Repository.CartProducts
{

    public class CartProductRepository : GenericRepository<CartProduct>, ICartProductRepository
    {
        private readonly DataContext _context;

        public CartProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<CartProduct> GetCartProductAsync(int cartId, int productId)
        {
            return await _context.CartProducts
                .Include(cp => cp.Product)
                .Include(cp => cp.Cart)
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        }

        public async Task<List<CartProduct>> GetCartProductsByCartIdAsync(int cartId)
        {
            return await _context.CartProducts
                .Include(cp => cp.Product)
                .Where(cp => cp.CartId == cartId)
                .ToListAsync();
        }
    }
}
