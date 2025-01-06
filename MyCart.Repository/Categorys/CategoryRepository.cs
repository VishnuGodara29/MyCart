using Microsoft.EntityFrameworkCore;
using MyCarData;
using MyCart.Domain.Categorys;
using MyCart.Repository.GenericRepositorys;

namespace MyCart.Repository.Categorys;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
    {
        return await _context.Categories
            .Where(c => c.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int parentId)
    {
        return await _context.Categories
            .Where(c => c.ParentId == parentId)
            .ToListAsync();
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}


