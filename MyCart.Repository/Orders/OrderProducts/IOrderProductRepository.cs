using MyCart.Domain.Orders;
using MyCart.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Repository.Orders.OrderProducts
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct>
    {
        Task<List<OrderProduct>> GetOrderProductsByOrderIdAsync(int orderId);
        Task<OrderProduct> GetOrderProductByIdAsync(int orderProductId);
    }
}
