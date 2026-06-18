using CW._21.Infrastructures.Repositories.Categories;
using CW._21.Services.DTOs;

namespace CW._21.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDetailDto>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }

    public async Task<CategoryDetailDto?> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }

    public async Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync()
    {
        return await _categoryRepository.GetCategoriesWithAvailableStockAsync();
    }

    public async Task<List<CategoryWithCountDto>> GetCategoriesWithBookCountAsync()
    {
        return await _categoryRepository.GetCategoriesWithBook();
    }
}