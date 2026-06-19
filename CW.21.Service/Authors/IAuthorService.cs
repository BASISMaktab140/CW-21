using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Authors;

namespace CW._21.Services.Authors
{
    public interface IAuthorService
    {
        Task<List<AuthorBookCountDto>> GetAllAuthorsAsync();

        Task<AuthorInfoDto?> GetAuthorByIdAsync(int id);
        
        Task<List<AuthorInfoDto>> GetAuthorsWithMoreThanTwoBooksAsync();

        Task<List<AuthorInfoDto>> SearchAuthorByNameAsync(string name);

        Task AddAuthorAsync(AuthorCreateDto authorDto);

        Task UpdateAuthorAsync(AuthorUpdateDto authorDto);

        Task DeleteAuthorAsync(int id);
    }
}
