using CW._21.Services.DTOs;
using CW._21.Services.DTOs.Books;

namespace CW._21.Services.Tags
{
    public  interface ITagService 
    {
        Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize);
        Task CreateTagAsync(string name);
        Task<TagInfoDto?> GetTagByIdAsync(int tagId);
        Task AddTagToBookAsync(int tagId, int bookId);
        Task RemoveTagFromBookAsync(int tagId, int bookId);
    }
}
