using MyCart.Domain.Enums.UserTypes;

namespace MyCart.Service.Dtos
{
    public class UserInDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Int32 PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public string? Password { get; set; }
        public UserType? UserType { get; set; }

        //public DateTime CreateDate { get; set; }
        
    }
}
