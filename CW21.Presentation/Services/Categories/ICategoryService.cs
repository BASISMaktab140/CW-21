using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Categories;

public interface ICategoryService 
{
    Task<List<CategoryDetailDto>?> GetAllCategoryBooks();
}