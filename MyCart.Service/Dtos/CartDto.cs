using MyCart.Domain.Users;

namespace MyCart.Service.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserInId { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
    }
}
