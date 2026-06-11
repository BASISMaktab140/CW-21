using CW21.Presentation.Entities.Books;
using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Books;

public interface IBookService
{
    Task<List<BookDetailDto>?> GetAllBooksWithDetailsAsync();
    
    Task<BookInfoDto> GetBookDetailsAsync(int id);
/// <summary>
/// سوال 4 بخش 6
/// </summary>
/// <param name="minimumQuantity"></param>
/// <returns></returns>
    Task<List<Book>?> GetBooksMeetCriteria(int minimumQuantity);
}