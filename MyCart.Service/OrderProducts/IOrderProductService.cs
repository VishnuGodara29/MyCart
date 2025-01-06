using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.OrderProducts
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProductDto>> GetAllOrderProductsAsync();
        Task<OrderProductDto> GetOrderProductByIdAsync(int id);
        Task AddOrderProductAsync(OrderProductDto orderProductDto);
        Task UpdateOrderProductAsync(int id, OrderProductDto orderProductDto);
        Task DeleteOrderProductAsync(int id);
    }
}
