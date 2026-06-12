using CW21.Presentation.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.Authors
{
    public interface IAuthorService
    {
        Task<List<AuthorBookCountDto>> GetAllAuthorsAsync();

        Task<AuthorInfoDto?> GetAuthorByIdAsync(int id);
        
        Task<List<AuthorInfoDto>> GetAuthorsWithMoreThanTwoBooksAsync();

        Task<List<AuthorInfoDto>> SearchAuthorByNameAsync(string name);

        Task<bool> AddAuthorAsync(AuthorCreateDto authorDto);

        Task<bool> UpdateAuthorAsync(AuthorUpdateDto authorDto);

        Task<bool> DeleteAuthorAsync(int id);
    }
}
