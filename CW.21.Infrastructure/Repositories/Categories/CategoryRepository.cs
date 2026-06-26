using CW._21.Domain.Categories;
using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Categories;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Categories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CategoryDetailDto>> GetAllCategoriesAsync()
    {
        return await DbSet
            .Select(c => new CategoryDetailDto(c.Name,
                c.Books.Select(b => b.Title).ToList(),
                c.Books.Select(b => b.Author.FullName).ToList()))
            .ToListAsync();
    }

    public async Task<CategoryDetailDto?> GetCategoryByIdAsync(int id)
    {
        return await DbSet
            .Where(c => c.Id == id)
            .Select(c => new CategoryDetailDto(c.Name,
                c.Books.Select(b => b.Title).ToList(),
                c.Books.Select(b => b.Author.FullName).ToList()))
            .FirstOrDefaultAsync();
    }

   
    public async Task<List<CategoryDetailDto>> GetCategoriesWithAvailableStockAsync()
    {
        return await  DbSet
            .Where(c => c.Books.Any(b => b.Stock > 0))
            .Select(category => new CategoryDetailDto(category.Name,
            category.Books.Select( b=> b.Title).ToList(),
            category.Books.Select(b => b.Author.FullName).ToList()))
            .ToListAsync(); 
    }

    public async Task<List<CategoryWithCountDto>> GetCategoriesWithBook()
    {
        return await  DbSet
            .Select(category => 
            new CategoryWithCountDto(category.Name, category.Books.Count))
            .ToListAsync();    }
}