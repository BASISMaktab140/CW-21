using CW21.Presentation.Data;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CW21.Presentation.Repositories.Generics;

namespace CW21.Presentation.Repositories.Tags
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
    
