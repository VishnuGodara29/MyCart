using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Repository.Products
{
    public class SearchProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
