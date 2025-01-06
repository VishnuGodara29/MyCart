using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Categorys;
using MyCart.Domain.Users;
using MyCart.Repository.GenericRepository;
using MyCart.Repository.GenericRepositorys;
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
    }
}
