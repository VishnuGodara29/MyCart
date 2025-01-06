using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Carts;
using MyCart.Repository.GenericRepositorys;

namespace MyCart.Repository.Carts
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly DataContext _context;

        public CartRepository(DataContext context) : base(context)
        {
        }

        public async Task<Cart> GetCartByUserIdAsync(int userInId)
        {
            return await _context.Carts
                .Include(c => c.UserIn) // Include related User
                .FirstOrDefaultAsync(c => c.UserInId == userInId);
        }
    }
}
