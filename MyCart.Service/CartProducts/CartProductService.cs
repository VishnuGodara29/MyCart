using AutoMapper;
using MyCart.Domain.Carts;
using MyCart.Repository.CartProducts;
using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.CartProducts
{

    public class CartProductService : ICartProductService
    {
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IMapper _mapper;

        public CartProductService(ICartProductRepository cartProductRepository, IMapper mapper)
        {
            _cartProductRepository = cartProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartProductDto>> GetAllCartProductsAsync()
        {
            var cartProducts = await _cartProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CartProductDto>>(cartProducts);
        }

        public async Task<CartProductDto> GetCartProductByIdAsync(int id)
        {
            var cartProduct = await _cartProductRepository.GetByIdAsync(id);
            if (cartProduct == null) return null;

            return _mapper.Map<CartProductDto>(cartProduct);
        }

        public async Task AddCartProductAsync(CartProductDto cartProductDto)
        {
            var cartProduct = _mapper.Map<CartProduct>(cartProductDto);
            await _cartProductRepository.AddAsync(cartProduct);
        }

        public async Task UpdateCartProductAsync(int id, CartProductDto cartProductDto)
        {
            var cartProduct = await _cartProductRepository.GetByIdAsync(id);
            if (cartProduct == null) return;

            _mapper.Map(cartProductDto, cartProduct);
            await _cartProductRepository.UpdateAsync(cartProduct);
        }

        public async Task DeleteCartProductAsync(int id)
        {
            await _cartProductRepository.DeleteAsync(id);
        }
    }
}
