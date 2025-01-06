using MyCart.Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Orders
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public decimal PayableAmount { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        

    }
}
