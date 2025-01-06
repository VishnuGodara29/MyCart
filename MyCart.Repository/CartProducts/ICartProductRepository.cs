using MyCart.Domain.Carts;
using MyCart.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Repository.CartProducts
{
    public interface ICartProductRepository : IGenericRepository<CartProduct>
    {
        Task<CartProduct> GetCartProductAsync(int cartId, int productId); 
        Task<List<CartProduct>> GetCartProductsByCartIdAsync(int cartId); 
    }
}
