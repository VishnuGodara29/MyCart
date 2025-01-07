using AutoMapper;
using MyCart.Domain.Categorys;
using MyCart.Domain.Users;
using MyCart.Repository.Logins;
using MyCart.Repository.Users;
using MyCart.Service.Dtos;
using MyCart.Service.Emails;

namespace MyCart.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IEmailService _emailService;
        // Constructor injection for repository and AutoMapper
        public UserService(IUserRepository userRepository, IMapper mapper, IUserLoginRepository userLoginRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userLoginRepository = userLoginRepository;
            _emailService = emailService;
        }

        // Get user by Id
        public async Task<UserInDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;  // If user is not found, return null

            return _mapper.Map<UserInDto>(user);  // Map the UserIn entity to UserDto and return
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _userRepository.GetByNameAsync(name);
        }
        public async Task<User> GetByPasswordAsync(string Password)
        {
            return await _userRepository.GetByPasswordAsync(Password);
        }


        // Get user by Email
        public async Task<UserInDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return null;  // If user is not found, return null

            return _mapper.Map<UserInDto>(user);  // Map the UserIn entity to UserDto and return
        }

        // Get user by PhoneNumber
        public async Task<UserInDto> GetUserByPhoneNumberAsync(int phoneNumber)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(phoneNumber);
            if (user == null) return null;  

            return _mapper.Map<UserInDto>(user);
        }

       

        // Update an existing user
        public async Task<UserInDto> UpdateUserAsync(int id, UserInDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            _mapper.Map(userDto, user);

            await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserInDto>(user);
        }

        public async Task<UserInDto> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            user.IsActive = false;

            await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserInDto>(user);
        }

       

        // Create a new user
        public async Task<UserInDto> CreateUserAsync(UserInDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            var userlogIn = new UserLogin
            {
                Name=userDto.Name,
                Password=userDto.Password,
                UserId=user.Id,
            };
            await _userLoginRepository.AddAsync(userlogIn);
            string subject = "For user Creation";
            string body = $"This Mail for the UserName and password UserName={userDto.Name} and password ={userDto.Password}";

            await _emailService.SendEmail(userDto.Email, subject, body);
           


            return _mapper.Map<UserInDto>(user);
        }
        public async Task<List<UserInDto>> GetAllUsersAsync()
        {
            // Retrieve all users from the repository
            var users = await _userRepository.GetAllAsync();

            var userDtos = _mapper.Map<List<UserInDto>>(users);

            return userDtos; // Return the list of DTOs
        }


    }
}
