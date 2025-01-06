using MyCart.Domain.Categorys;
using MyCart.Domain.Users;
using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.Users
{
    public interface IUserService
    {
        Task<UserInDto> GetByIdAsync(int id);
        // Get user by Id
        Task<UserInDto> GetUserByEmailAsync(string email);    // Get user by Email
        Task<UserInDto> GetUserByPhoneNumberAsync(int phoneNumber); // Get user by Phone Number
        Task<UserInDto> UpdateUserAsync(int id, UserInDto userDto);  // Update an existing user
        Task<UserInDto> DeleteUserAsync(int id);              // Soft delete a user
        Task<UserInDto> CreateUserAsync(UserInDto userDto);
        Task<List<UserInDto>> GetAllUsersAsync();
        Task<User> GetByNameAsync(string name);
        Task<User> GetByPasswordAsync(string Password);


    }
}
