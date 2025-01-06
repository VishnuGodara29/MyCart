using MyCart.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Orders
{
    public class Order
    {

        public int Id { get; set; }
        [ForeignKey("UserIn")]

        public int UserInId { get; set; }

        public string OrderNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal PayableAmount { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string Status { get; set; }

        public User UserIn { get; set; }
    }
}
