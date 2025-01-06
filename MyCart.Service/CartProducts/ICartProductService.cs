using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.CartProducts
{
    public interface ICartProductService
    {
        Task<IEnumerable<CartProductDto>> GetAllCartProductsAsync();
        Task<CartProductDto> GetCartProductByIdAsync(int id);
        Task AddCartProductAsync(CartProductDto cartProductDto);
        Task UpdateCartProductAsync(int id, CartProductDto cartProductDto);
        Task DeleteCartProductAsync(int id);
    }
}
