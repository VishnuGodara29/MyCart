using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Users;
using MyCart.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Repository.Logins
{
    public class UserLoginsRepository : IGenericRepository<UserLogin>, IUserLoginRepository
    {
        private readonly DataContext _dataContext;

        public UserLoginsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(UserLogin entity)
        {
            var userlogin = new UserLogin
            {
                Name = entity.Name,
                Password = entity.Password,
                UserId = entity.UserId,

            };
            await _dataContext.UserLogins.AddAsync(userlogin);
            await _dataContext.SaveChangesAsync();
            return;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserLogin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserLogin> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLogin> GetByUserId(int UserId)
        {
           var userLogin= await _dataContext.UserLogins.FirstOrDefaultAsync(x=>x.UserId==UserId);
            if (userLogin != null)
            {
                return userLogin;
            }
            return null;
        }

        public async Task<UserLogin> GetUserLoginByCodeAsync(string Name)
        {
            var data = await _dataContext.UserLogins.Where(x => x.Name == Name).FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public Task UpdateAsync(UserLogin entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyUserCredentialsAsync(string Name, string password)
        {
            var data= await _dataContext.UserLogins.FirstOrDefaultAsync(x=>x.Name==Name&&x.Password==password);
            if (data == null)
            {
                return false;
            }
            return true;
        }
    }
}
