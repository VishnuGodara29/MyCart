using MyCart.Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Carts
{
    public class CartProduct
    {

        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public decimal NetAmount { get; set; }

       
       
    }
}
