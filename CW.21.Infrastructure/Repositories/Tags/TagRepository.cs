using CW._21.Domain.Tags;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using CW._21.Services.DTOs;
using CW._21.Services.DTOs.Books;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Tags
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize)
        {
            return await  _dbSet.AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(tag => new TagInfoDto(
                tag.Id,
                tag.Name,
                tag.BookTags.Count)).ToListAsync();
        }
    }
}
    
