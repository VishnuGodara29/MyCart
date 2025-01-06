
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCart.Domain.Users
{
    public class UserLogin
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
