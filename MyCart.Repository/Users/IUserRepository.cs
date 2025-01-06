using MyCart.Domain.Users;
using MyCart.Repository.GenericRepository;

namespace MyCart.Repository.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByPhoneNumberAsync(int PhoneNumber);

        Task<User> GetByPasswordAsync(string Password);

        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNameAsync(string name);
    }
}
