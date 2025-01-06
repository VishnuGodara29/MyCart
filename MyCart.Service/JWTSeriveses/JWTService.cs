using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyCart.Domain.Users;
using MyCart.Repository.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.JWTSeriveses
{
    public class JWTService : IJWTService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public JWTService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> GenrateJwt(User user)
        {
            string userType = user.UserType.ToString();
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var CustomClaim = new List<Claim>
            {
                new Claim("Id",user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("UserType", userType),
                new Claim(ClaimTypes.Role, userType)

            };
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
               issuer: issuer,
               audience: audience,
               claims: CustomClaim,
             expires: DateTime.Now.AddMinutes(5),
               signingCredentials: signinCredentials
           );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
