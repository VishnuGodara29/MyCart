using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCart.Repository.Products.Dtos.ChangePassword;
using MyCart.Service.Dtos;
using MyCart.Service.Dtos.UserLogins;

namespace MyCart.Service.UserLogins
{
    public interface IUserLoginService
    {
        Task<IEnumerable<UserLoginDto>> GetAllUserLoginsAsync();
        Task<UserLoginDto> GetUserLoginByIdAsync(int id);
        Task AddUserLoginAsync(UserLoginDto userLoginDto);
        Task UpdateUserLoginAsync(int id, UserLoginDto userLoginDto);
        Task DeleteUserLoginAsync(int id);

        Task<(string Token, string Message)> UserLogin(LoginDto loginDto);
        Task<(bool IsSuccess, string Message)> UserLoginAsync(int userId, ChangePasswordDto changePasswordDto);
    }
}
