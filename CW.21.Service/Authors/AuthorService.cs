using CW._21.Domain.Authors;
using CW._21.Domain.DTOs;

namespace CW._21.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

       
        public async Task<List<AuthorBookCountDto>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAuthorsBooksCountAsync();
        }

       
        public async Task<AuthorInfoDto?> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAuthorInfoAsync(id);

        }
      
        public async Task<List<AuthorInfoDto>> GetAuthorsWithMoreThanTwoBooksAsync()
        {
            return await _authorRepository.GetAuthorsWithMultipleBooksAsync();
        }

   
        public async Task<List<AuthorInfoDto>> SearchAuthorByNameAsync(string name)
        {
            return await _authorRepository.FindAuthorByNameAsync(name);
        }

        public async Task AddAuthorAsync(AuthorCreateDto authorDto)
        {
            var newAuthor = new Author
            (
                authorDto.FullName,
                authorDto.BirthYear,
                authorDto.Country);
             await _authorRepository.AddAsync(newAuthor);
        }

        public async Task UpdateAuthorAsync(AuthorUpdateDto authorDto)
        {
            var author = await _authorRepository.GetByIdAsync(authorDto.Id);
            if(author == null)
                throw new KeyNotFoundException();
            
            author.FullName = authorDto.FullName;
            author.BirthYear = authorDto.BirthYear;
            author.Country = authorDto.Country;
            await _authorRepository.UpdateAsync(author);
            
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }
    }
}
