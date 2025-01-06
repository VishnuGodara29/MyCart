using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Users;
using MyCart.Repository.GenericRepositorys;

namespace MyCart.Repository.Logins
{

    public class UserLoginRepository : GenericRepository<UserLogin>, IUserLoginRepository
    {
        private readonly DataContext _context;

        public UserLoginRepository(DataContext context) : base(context)
        {
        }
        public async Task<UserLogin> GetUserLoginByCodeAsync(string Name)
        {
            return await _context.UserLogins
                .Where(u => u.Name == Name)
                .FirstOrDefaultAsync();
        }
            
        // Method to verify user credentials (Code + Password)
        public async Task<bool> VerifyUserCredentialsAsync(string Name, string password)
        {
            var userLogin = await _context.UserLogins
                .Where(u => u.Name == Name)
                .FirstOrDefaultAsync();

            return userLogin != null && userLogin.Password == password; // Compare password (in practice, you should use hashed password comparison)
        }
    }
}
