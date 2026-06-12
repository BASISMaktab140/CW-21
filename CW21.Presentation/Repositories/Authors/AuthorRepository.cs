using CW21.Presentation.Data;
using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Repositories.Authors;

public class AuthorRepository : GenericRepository<Author> , IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }


}