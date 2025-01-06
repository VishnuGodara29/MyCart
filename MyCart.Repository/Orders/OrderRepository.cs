using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Orders;
using MyCart.Repository.GenericRepositorys;

namespace MyCart.Repository.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context) : base(context)
        {
        }

        // Get order by ID
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.UserIn)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userInId)
        {
            return await _context.Orders
                .Include(o => o.UserIn)
                .Where(o => o.UserInId == userInId)
                .ToListAsync();
        }
    }
}
