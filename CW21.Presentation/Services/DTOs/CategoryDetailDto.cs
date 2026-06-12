using CW21.Presentation.Entities.Categories;

namespace CW21.Presentation.Services.DTOs;

public record CategoryDetailDto(string CategoryName, List<string> BookNames, List<string> AuthorsFullName);
public record CategoryWithCountDto(string CategoryName, int BookCount);


public static class CategoryMapper{
    
    public static CategoryDetailDto GetAllCategoryBooksMapper(this Category category)
    {
        return new CategoryDetailDto(category.Name,
            category.Books.Select( b=> b.Title).ToList(),
            category.Books.Select(b => b.Author.FullName).ToList());
    }
    public static CategoryWithCountDto GetCategoryWithCountMapper(this Category category)
    {
        return new CategoryWithCountDto(category.Name, category.Books.Count);
    }


}