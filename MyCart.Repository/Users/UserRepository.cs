using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Categorys;
using MyCart.Domain.Users;
using MyCart.Repository.GenericRepository;
using MyCart.Repository.GenericRepositorys;
using MyCart.Repository.Products.Dtos.ChangePassword;
using System.Threading.Tasks;

namespace MyCart.Repository.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByPhoneNumberAsync(int phoneNumber)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber); // Assuming `PhoneNumber` is a string
        }

        /*public async Task<User> GetByPasswordAsync(string password)
        {
            // You should compare passwords securely, using hashed passwords
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Password == password); // Ensure you're storing hashed passwords in the DB
        }*/

        Task<User> IUserRepository.GetByPhoneNumberAsync(int PhoneNumber)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByPasswordAsync(string Password)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _context.Users
                .FirstOrDefaultAsync(c => c.Name.ToLower()==name.ToLower());
        }

        public async Task<(bool IsSuccess, string Message)> ChangePassword(int userId,ChangePasswordDto changePasswordDto)
        {
            var user= await _context.Users.AnyAsync(x=>x.Id==userId);
            if (!user)
            {
                return (false,"user not found");
            }
           
            var useLogin=await _context.UserLogins.FirstOrDefaultAsync(x=>x.UserId==userId&&x.Password==changePasswordDto.OldPassword);
            if (useLogin == null)
            {
                return (false, "Your old password was incorrect");
            }

            useLogin.Password = changePasswordDto.NewPassword;
             _context.UserLogins.Update(useLogin);
            _context.SaveChanges();
            return (true,"Change successfully");

        }
    }
}
