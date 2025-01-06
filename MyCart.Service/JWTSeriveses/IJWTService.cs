using MyCart.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.JWTSeriveses
{
    public interface IJWTService
    {
        Task<string> GenrateJwt(User user);
    }
}
