using CW21.Presentation.Data;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Repositories.Generics;

namespace CW21.Presentation.Repositories.Categories;

public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}