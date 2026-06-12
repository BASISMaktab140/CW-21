using CW21.Presentation.Entities.Books;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Repositories.Books;

public interface IBookRepository : IGenericRepository<Book>
{
    
    Task<List<BookInfoDto>> GetAuthorBooksAsync(int authorId);

}