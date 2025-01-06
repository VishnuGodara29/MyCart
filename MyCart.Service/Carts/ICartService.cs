using MyCart.Domain.Carts;
using MyCart.Service.Dtos;

namespace MyCart.Service.Carts
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetAllCartsAsync();
        Task<CartDto> GetCartByIdAsync(int id);
        Task AddCartAsync(CartDto cartDto);
        Task UpdateCartAsync(int id, CartDto cartDto);
        Task DeleteCartAsync(int id);
    }
}
