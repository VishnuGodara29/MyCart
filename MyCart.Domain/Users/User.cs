using MyCart.Domain.Enums.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Domain.Users
{
        public class User
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public Int32 PhoneNumber { get; set; }
            public UserType UserType { get; set; }

            public bool IsActive { get; set; }

            public DateTime CreateDate { get; set; }=DateTime.Now;

            public DateTime? UpdateDate { get; set; }

    }
}
