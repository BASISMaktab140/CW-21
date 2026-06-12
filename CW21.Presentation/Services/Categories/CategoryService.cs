using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Repositories.Categories;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDetailDto>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAll()
                .Include(c => c.Books)
                .ThenInclude(b => b.Author)
                .Select(c => c.GetAllCategoryBooksMapper())
                .ToListAsync();
    }

    public async Task<CategoryDetailDto?> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetAll(c => c.Id == id)
                .Include(c => c.Books)
                .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync();

        if (category == null)
            return null;

        return category.GetAllCategoryBooksMapper();
    }

    public async Task<CategoryDetailDto?> GetBooksByCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetAll(c => c.Id == id)
                .Include(c => c.Books)
                .ThenInclude(b => b.Author)
                .FirstOrDefaultAsync();

        if (category == null)
            return null;

        return category.GetAllCategoryBooksMapper();
    }

    public async Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync()
    {
        return await _categoryRepository.GetAll().Include(c => c.Books)
                                .ThenInclude(b => b.Author)
                                .Where(c => c.Books.Any(b => b.Stock > 0))
                                .Select(c => c.GetAllCategoryBooksMapper())
                                .ToListAsync();
    }

    public async Task<List<CategoryWithCountDto>> GetCategoriesWithBookCountAsync()
    {
        return await _categoryRepository.GetAll().Include(c => c.Books)
                            .Select(c => c.GetCategoryWithCountMapper())
                            .ToListAsync();
    }
}