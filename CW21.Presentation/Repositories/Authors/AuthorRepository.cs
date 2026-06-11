using CW21.Presentation.Data;
using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Repositories.Generics;

namespace CW21.Presentation.Repositories.Authurs;

public class AuthorRepository : GenericRepository<Author> , IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}