using CW21.Presentation.Entities.Books;
using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Books;

public interface IBookService
{
    Task<List<BookDetailDto>?> GetAllBooksWithDetailsAsync();

    Task<BookInfoDto?> GetBookDetailsAsync(int id);
    Task<List<BookInfoDto>> GetAvailableBooksAsync();
    Task<List<BookInfoDto>> GetBookByTitleAsync(string title);
    Task<bool> AddBookAsync(BookInfoDto bookInfo);
    Task<List<Book>?> GetBooksMeetCriteria(int minimumQuantity);
}