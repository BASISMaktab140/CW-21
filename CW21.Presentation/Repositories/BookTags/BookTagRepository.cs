using CW21.Presentation.Data;
using CW21.Presentation.Entities.BookTags;
using CW21.Presentation.Repositories.Generics;

namespace CW21.Presentation.Repositories.BookTags;

public class BookTagRepository : GenericRepository<BookTag> , IBookTagRepository
{
    public BookTagRepository(AppDbContext context) : base(context)
    {
    }
}