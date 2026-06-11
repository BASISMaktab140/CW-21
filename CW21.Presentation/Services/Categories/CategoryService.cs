using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Repositories.Categories;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Services.Categories;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository) {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDetailDto>?> GetAllCategoryBooks()
    {
        return await _categoryRepository.GetAll()
            .Include(x => x.Books)
            .ThenInclude(a => a.Author)
            .Select(x => x.GetAllCategoryBooksMapper()).ToListAsync();
    }
}