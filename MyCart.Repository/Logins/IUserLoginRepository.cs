using MyCart.Domain.Users;
using MyCart.Repository.GenericRepository;

namespace MyCart.Repository.Logins
{
    public interface IUserLoginRepository : IGenericRepository<UserLogin>
    {
        Task<UserLogin> GetUserLoginByCodeAsync(string Name);

        Task<bool> VerifyUserCredentialsAsync(string Name, string password);
        Task<UserLogin> GetByUserId(int UserId);
    }
}

