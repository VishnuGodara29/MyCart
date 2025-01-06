using AutoMapper;
using MyCart.Domain.Orders;
using MyCart.Repository.Orders.OrderProducts;
using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.OrderProducts
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;

        public OrderProductService(IOrderProductRepository orderProductRepository, IMapper mapper)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderProductDto>> GetAllOrderProductsAsync()
        {
            var orderProducts = await _orderProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderProductDto>>(orderProducts);
        }

        public async Task<OrderProductDto> GetOrderProductByIdAsync(int id)
        {
            var orderProduct = await _orderProductRepository.GetByIdAsync(id);
            if (orderProduct == null) return null;

            return _mapper.Map<OrderProductDto>(orderProduct);
        }

        public async Task AddOrderProductAsync(OrderProductDto orderProductDto)
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductDto);
            await _orderProductRepository.AddAsync(orderProduct);
        }

        public async Task UpdateOrderProductAsync(int id, OrderProductDto orderProductDto)
        {
            var orderProduct = await _orderProductRepository.GetByIdAsync(id);
            if (orderProduct == null) return;

            _mapper.Map(orderProductDto, orderProduct);
            await _orderProductRepository.UpdateAsync(orderProduct);
        }

        public async Task DeleteOrderProductAsync(int id)
        {
            await _orderProductRepository.DeleteAsync(id);
        }
    }
}
