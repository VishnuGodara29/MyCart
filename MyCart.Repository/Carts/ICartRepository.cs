using MyCart.Domain.Carts;
using MyCart.Repository.GenericRepository;

namespace MyCart.Repository.Carts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(int userInId);
    }
}
