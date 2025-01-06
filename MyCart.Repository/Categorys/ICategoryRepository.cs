using MyCart.Domain.Categorys;
using MyCart.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Repository.Categorys
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();

        Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int parentId);

        Task<Category> GetByNameAsync(string name);

    }
}
