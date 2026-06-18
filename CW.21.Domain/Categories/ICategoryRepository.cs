using CW._21.Domain.DTOs;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Categories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<List<CategoryDetailDto>> GetAllCategoriesAsync();
    Task<CategoryDetailDto?> GetCategoryByIdAsync(int id);
    Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync();
    Task<List<CategoryWithCountDto>> GetCategoriesWithBook();
}