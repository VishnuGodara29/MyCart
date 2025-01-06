using AutoMapper;
using MyCart.Domain.Categorys;
using MyCart.Repository.Categorys;
using MyCart.Service.Dtos;

namespace MyCart.Service.Categorys
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        // Get all categories
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDTOs = _mapper.Map<List<CategoryDto>>(categories);
            return categoryDTOs;
        }

        // Get category by ID
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            var categoryDTO = _mapper.Map<CategoryDto>(category);
            return categoryDTO;
        }

        // Get active categories
        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
        {
            return await _categoryRepository.GetActiveCategoriesAsync();
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int parentId)
        {
            return await _categoryRepository.GetCategoriesByParentIdAsync(parentId);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);

            var createdCategoryDto = _mapper.Map<CategoryDto>(category);
            return createdCategoryDto;
        }

        // Update an existing category
        public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            // Map the DTO to the existing category entity
            _mapper.Map(categoryDto, existingCategory);

            await _categoryRepository.UpdateAsync(existingCategory);

            // Return the updated category as a DTO
            var updatedCategoryDto = _mapper.Map<CategoryDto>(existingCategory);
            return updatedCategoryDto;
        }

        // Delete a category
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            await _categoryRepository.DeleteAsync(id);
        }
    }
}
