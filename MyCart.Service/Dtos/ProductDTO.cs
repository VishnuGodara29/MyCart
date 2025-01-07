using MyCart.Domain.Categorys;
using MyCart.Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Service.Dtos
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsActive { get; set; }
        public int ?CategoryId { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; } 
        public CategoryDto Category { get; set; }
    }


    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
