using CW21.Presentation.Data;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Repositories.Books;

public class BookRepository : GenericRepository<Book>,IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }
}