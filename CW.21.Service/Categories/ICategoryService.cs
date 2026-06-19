using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Categories;

namespace CW._21.Services.Categories;

public interface ICategoryService 
{
    Task<List<CategoryDetailDto>> GetAllCategoriesAsync();
    Task<CategoryDetailDto?> GetCategoryByIdAsync(int id);
    Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync();
    Task<List<CategoryWithCountDto>> GetCategoriesWithBookCountAsync();
}