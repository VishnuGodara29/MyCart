using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Categorys
{
    public class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Category Parent { get; set; }
    }
}
