using AutoMapper;
using MyCart.Domain.Users;
using MyCart.Repository.Logins;
using MyCart.Repository.Products.Dtos.ChangePassword;
using MyCart.Repository.Users;
using MyCart.Service.Dtos;
using MyCart.Service.Dtos.UserLogins;
using MyCart.Service.JWTSeriveses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.UserLogins
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IMapper _mapper;
        private readonly IJWTService _jWTService;
        private readonly IUserRepository _userRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository, IMapper mapper, IJWTService jWTService, IUserRepository userRepository)
        {
            _userLoginRepository = userLoginRepository;
            _mapper = mapper;
            _jWTService = jWTService;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserLoginDto>> GetAllUserLoginsAsync()
        {
            var userLogins = await _userLoginRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserLoginDto>>(userLogins);
        }

        public async Task<UserLoginDto> GetUserLoginByIdAsync(int id)
        {
            var userLogin = await _userLoginRepository.GetByIdAsync(id);
            if (userLogin == null) return null;

            return _mapper.Map<UserLoginDto>(userLogin);
        }

        public async Task AddUserLoginAsync(UserLoginDto userLoginDto)
        {
            var userLogin = _mapper.Map<UserLogin>(userLoginDto);
            await _userLoginRepository.AddAsync(userLogin);
        }

        public async Task UpdateUserLoginAsync(int id, UserLoginDto userLoginDto)
        {
            var userLogin = await _userLoginRepository.GetByIdAsync(id);
            if (userLogin == null) return;

            _mapper.Map(userLoginDto, userLogin);
            await _userLoginRepository.UpdateAsync(userLogin);
        }

        public async Task DeleteUserLoginAsync(int id)
        {
            await _userLoginRepository.DeleteAsync(id);
        }

        public async Task<(string Token, string Message)> UserLogin(LoginDto loginDto)
        {
            var CheckUser=await _userRepository.GetByNameAsync(loginDto.Name);
            if (CheckUser == null)
            {
                return(null,"Invalid code");
            }
            var userLogin= await _userLoginRepository.VerifyUserCredentialsAsync(loginDto.Name,loginDto.Password);
            if (userLogin==false)
            {
                return (null, "Invalid password");
            }
            var token = await _jWTService.GenrateJwt(CheckUser);
            if (token == null)
            {
                return (null, "Token not genrated..");
            }
                return(token,"Login successfully..");

        }

        public async Task<(bool IsSuccess, string Message)> UserLoginAsync(int userId, ChangePasswordDto changePasswordDto)
        {
            var chagnePassowrd= await _userRepository.ChangePassword(userId,changePasswordDto);
            if (chagnePassowrd.IsSuccess==false)
            {
                return (false,chagnePassowrd.Message);
            }
            return (true,chagnePassowrd.Message);
        }
    }
}
