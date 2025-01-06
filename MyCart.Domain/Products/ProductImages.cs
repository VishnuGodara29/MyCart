using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Products
{
    public class ProductImages
    {
        public int Id { get; set; }

        public string? ImagePath { get; set; }
        [ForeignKey("Product")]

        public int ProductId { get; set; }

        public Product? Product { get; set; }

    }
}
