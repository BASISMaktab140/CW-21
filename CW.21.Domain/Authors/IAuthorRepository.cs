using CW._21.Domain.Authors;
using CW._21.Infrastructures.Repositories.Generics;
using CW._21.Services.DTOs;
using CW._21.Services.DTOs.Books;

namespace CW._21.Infrastructures.Repositories.Authors;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<List<AuthorBookCountDto>> GetAuthorsBooksCountAsync();
    Task<AuthorInfoDto?> GetAuthorInfoAsync(int id);
    Task<List<AuthorInfoDto>> GetAuthorsWithMultipleBooksAsync();
    Task<List<AuthorInfoDto>> FindAuthorByNameAsync(string name);
}