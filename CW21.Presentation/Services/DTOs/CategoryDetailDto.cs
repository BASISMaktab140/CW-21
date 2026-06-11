using CW21.Presentation.Entities.Categories;

namespace CW21.Presentation.Services.DTOs;

public record CategoryDetailDto(string CategoryName, List<string> BookNames, List<string> AuthorsFullName);

public static class CategoryMapper{
    
    public static CategoryDetailDto GetAllCategoryBooksMapper(this Category category)
    {
        return new CategoryDetailDto(category.Name,
            category.Books.Select( b=> b.Title).ToList(),
            category.Books.Select(b => b.Author.FullName).ToList());
    }
    
}