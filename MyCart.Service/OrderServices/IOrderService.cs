using MyCart.Domain.Orders;
using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.OrderServices
{
    public interface IOrderService
    {
        //Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        //Task DeleteOrderAsync(int id);
        //Task<List<OrderDto>> GetAllOrdersAsync();
        //Task<OrderDto> GetOrderByIdAsync(int id);
        //Task GetOrdersByUserIdAsync(int userId);
        //Task UpdateOrderAsync(int id, Order order);
        //Task UpdateOrderAsync(int id, OrderDto order);
        //Task UpdateOrderAsync(OrderDto orderDto);

        Task CreateOrderAsync(OrderDto orderDto);
        Task DeleteOrderAsync(int id);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task UpdateOrderAsync(OrderDto orderDto);
    }
}
