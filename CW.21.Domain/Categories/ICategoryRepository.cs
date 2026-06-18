using CW._21.Domain.Categories;
using CW._21.Infrastructures.Repositories.Generics;
using CW._21.Services.DTOs;

namespace CW._21.Infrastructures.Repositories.Categories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<List<CategoryDetailDto>> GetAllCategoriesAsync();
    Task<CategoryDetailDto?> GetCategoryByIdAsync(int id);
    Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync();
    Task<List<CategoryWithCountDto>> GetCategoriesWithBook();
}