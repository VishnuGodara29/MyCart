using MyCart.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Carts
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserIn")]

        public int UserInId { get; set; }

        public DateTime CreateDate { get; set; }

        public User UserIn { get; set; }
    }
}
