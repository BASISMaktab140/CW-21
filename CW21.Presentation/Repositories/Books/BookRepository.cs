using CW21.Presentation.Data;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Repositories.Books;

public class BookRepository : GenericRepository<Book>,IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<BookInfoDto>> GetAuthorBooksAsync(int authorId)
    {
      return await _context.Books
          .Where(b=> b.AuthorId == authorId)
            .Select( b => 
            new BookInfoDto(b.Title, b.Price, b.Stock, b.PublishYear,
            b.Author, b.Category, b.Publisher
            , b.BookTags.Select(t => t.Tag).ToList())).ToListAsync();
    }
}