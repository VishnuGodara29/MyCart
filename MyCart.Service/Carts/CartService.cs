using AutoMapper;
using MyCart.Domain.Carts;
using MyCart.Repository.Carts;
using MyCart.Service.Dtos;

namespace MyCart.Service.Carts
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartDto>> GetAllCartsAsync()
        {
            var carts = await _cartRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CartDto>>(carts);
        }

        public async Task<CartDto> GetCartByIdAsync(int id)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null) return null;

            return _mapper.Map<CartDto>(cart);
        }

        public async Task AddCartAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            await _cartRepository.AddAsync(cart);
        }

        public async Task UpdateCartAsync(int id, CartDto cartDto)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null) return;

            _mapper.Map(cartDto, cart); // Updates existing cart object
            await _cartRepository.UpdateAsync(cart);
        }

        public async Task DeleteCartAsync(int id)
        {
            await _cartRepository.DeleteAsync(id);
        }
    }
}
