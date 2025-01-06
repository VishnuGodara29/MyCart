using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Orders;
using MyCart.Repository.GenericRepositorys;

namespace MyCart.Repository.Orders.OrderProducts
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly DataContext _context;

        public OrderProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<OrderProduct>> GetOrderProductsByOrderIdAsync(int orderId)
        {
            return await _context.OrderProducts
                .Include(op => op.Product)
                .Where(op => op.OrderId == orderId)
                .ToListAsync();
        }

        // Get a specific OrderProduct by its ID
        public async Task<OrderProduct> GetOrderProductByIdAsync(int orderProductId)
        {
            return await _context.OrderProducts
                .Include(op => op.Product)  // Include related Product entity
                .FirstOrDefaultAsync(op => op.Id == orderProductId);
        }
    }
}
