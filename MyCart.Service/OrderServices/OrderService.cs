using AutoMapper;
using MyCart.Domain.Orders;
using MyCart.Repository.Orders;
using MyCart.Service.Dtos;

namespace MyCart.Service.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.CreateDate = DateTime.Now; // Ensure the date is set
            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(orderDto.Id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            _mapper.Map(orderDto, order);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            await _orderRepository.DeleteAsync(id);
        }


    }
}


