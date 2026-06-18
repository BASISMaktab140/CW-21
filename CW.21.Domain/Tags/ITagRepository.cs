using CW._21.Domain.Tags;
using CW._21.Infrastructures.Repositories.Generics;
using CW._21.Services.DTOs;
using CW._21.Services.DTOs.Books;

namespace CW._21.Infrastructures.Repositories.Tags
{
   public interface ITagRepository : IGenericRepository<Tag>
   {
       Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize);
   }
}
