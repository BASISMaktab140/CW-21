using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Categories;

public interface ICategoryService 
{
    Task<List<CategoryDetailDto>> GetAllCategoriesAsync();
    Task<CategoryDetailDto?> GetCategoryByIdAsync(int id);
    Task<CategoryDetailDto?> GetBooksByCategoryAsync(int id);
    Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync();
    Task<List<CategoryWithCountDto>> GetCategoriesWithBookCountAsync();
}