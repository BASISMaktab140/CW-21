using CW._21.Domain.Authors;
using CW._21.Domain.DTOs.Authors;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Authors;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<AuthorBookCountDto>> GetAuthorsBooksCountAsync()
    {
        return await DbSet
            .Select(a => new AuthorBookCountDto(
                a.Id,
                a.FullName,
                a.Books.Count()
            ))
            .ToListAsync();
    }

    public async Task<AuthorInfoDto?> GetAuthorInfoAsync(int id)
    {
        return await DbSet
            .Select(a => new AuthorInfoDto(
                a.Id,
                a.FullName,
                a.BirthYear,
                a.Country
            ))
            .FirstOrDefaultAsync();
    }

    public async Task<List<AuthorInfoDto>> GetAuthorsWithMultipleBooksAsync()
    {
        return await DbSet
            .Where(a => a.Books.Count() > 2)
            .Select(a => new AuthorInfoDto(
                a.Id,
                a.FullName,
                a.BirthYear,
                a.Country
            ))
            .ToListAsync();
    }

    public async Task<List<AuthorInfoDto>> FindAuthorByNameAsync(string name)
    {
        return await DbSet
            .Where(a => a.FullName.Contains(name))
            .Select(a => new AuthorInfoDto(
                a.Id,
                a.FullName,
                a.BirthYear,
                a.Country
            ))
            .ToListAsync();
    }
}