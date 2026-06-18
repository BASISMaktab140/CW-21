using CW._21.Domain.DTOs;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Tags
{
   public interface ITagRepository : IGenericRepository<Tag>
   {
       Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize);
   }
}
