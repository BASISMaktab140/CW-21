using CW._21.Domain.BookTags;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;

namespace CW._21.Infrastructures.Repositories.BookTags;

public class BookTagRepository : GenericRepository<BookTag>, IBookTagRepository
{
    public BookTagRepository(AppDbContext context) : base(context)
    {
    }
}