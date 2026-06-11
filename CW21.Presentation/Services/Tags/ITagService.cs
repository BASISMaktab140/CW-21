using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Tags;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.Tags
{
    public  interface ITagService 
    {
        Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize);
        Task<List<BookInfoByTagDto>> GetBooksByTagAsync(int tagId, int page, int pageSize);
        Task CreateTagAsync(string name);
        Task<TagInfoDto?> GetTagByIdAsync(int tagId);
        Task AddTagToBookAsync(int tagId, int bookId);
        Task RemoveTagFromBookAsync(int tagId, int bookId);
    }
}
