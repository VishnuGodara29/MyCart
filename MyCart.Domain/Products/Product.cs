using MyCart.Domain.Categorys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyCart.Domain.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; } 
        public Category Category { get; set; } 
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime UpdateDate { get; set; }=DateTime.Now;
    }
}
