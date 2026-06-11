using CW21.Presentation.Data;
using CW21.Presentation.Entities.Publishers;
using CW21.Presentation.Repositories.Generics;

namespace CW21.Presentation.Repositories.Publishers;

public class PublisherRepository : GenericRepository<Publisher> , IPublisherRepository
{
    public PublisherRepository(AppDbContext context) : base(context)
    {
    }
}