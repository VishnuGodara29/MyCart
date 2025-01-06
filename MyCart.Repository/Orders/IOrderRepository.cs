using MyCart.Domain.Orders;
using MyCart.Repository.GenericRepository;

namespace MyCart.Repository.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByUserIdAsync(int userInId);
    }
}
