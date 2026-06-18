using CW._21.Domain.DTOs;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Authors;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<List<AuthorBookCountDto>> GetAuthorsBooksCountAsync();
    Task<AuthorInfoDto?> GetAuthorInfoAsync(int id);
    Task<List<AuthorInfoDto>> GetAuthorsWithMultipleBooksAsync();
    Task<List<AuthorInfoDto>> FindAuthorByNameAsync(string name);
}