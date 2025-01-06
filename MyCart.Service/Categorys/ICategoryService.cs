using MyCart.Domain.Categorys;
using MyCart.Service.Dtos;

namespace MyCart.Service.Categorys
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int parentId);
        Task<Category> GetByNameAsync(string name);
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}
