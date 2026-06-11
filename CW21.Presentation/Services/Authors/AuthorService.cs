using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Repositories.Authors;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.Authors
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
            return await _authorRepository.GetAll()
                .Select(a => new AuthorBookCountDto(
                    a.Id,
                    a.FullName,
                    a.Books.Count()
                ))
                .ToListAsync();
        }

       
        public async Task<AuthorInfoDto?> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAll(a => a.Id == id)
                .Select(a => new AuthorInfoDto(
                    a.Id,
                    a.FullName,
                    a.BirthYear,
                    a.Country
                ))
                .FirstOrDefaultAsync();
        }

        
        public async Task<List<BookInfoDto>> GetAuthorBooksAsync(int authorId)
        {
            return await _authorRepository.GetAll(a => a.Id == authorId)
                .Include(a => a.Books)
                    .ThenInclude(b => b.Author)
                .Include(a => a.Books)
                    .ThenInclude(b => b.Category)
                .Include(a => a.Books)
                    .ThenInclude(b => b.Publisher)
                .Include(a => a.Books)
                    .ThenInclude(b => b.BookTags)
                        .ThenInclude(bt => bt.Tag)
                .SelectMany(a => a.Books)
                .Select(b => b.BookInfoMapper())
                .ToListAsync();
        }

      
        public async Task<List<AuthorInfoDto>> GetAuthorsWithMoreThanTwoBooksAsync()
        {
            return await _authorRepository.GetAll()
                .Where(a => a.Books.Count() > 2)
                .Select(a => new AuthorInfoDto(
                    a.Id,
                    a.FullName,
                    a.BirthYear,
                    a.Country
                ))
                .ToListAsync();
        }

   
        public async Task<List<AuthorInfoDto>> SearchAuthorByNameAsync(string name)
        {
            return await _authorRepository.GetAll(a =>
                    a.FullName.Contains(name))
                .Select(a => new AuthorInfoDto(
                    a.Id,
                    a.FullName,
                    a.BirthYear,
                    a.Country
                ))
                .ToListAsync();
        }


        public async Task<bool> AddAuthorAsync(AuthorCreateDto authorDto)
        {
            if (string.IsNullOrWhiteSpace(authorDto.FullName))
                throw new Exception("FullName is required");

            var author = new Author
            {
                FullName = authorDto.FullName,
                BirthYear = authorDto.BirthYear,
                Country = authorDto.Country
            };

            await _authorRepository.AddAsync(author);

            return true;
        }

        public async Task<bool> UpdateAuthorAsync(AuthorUpdateDto authorDto)
        {
            var author = await _authorRepository.GetByIdAsync(authorDto.Id, true);

            if (author == null)
                throw new KeyNotFoundException("Author not found");

            author.FullName = authorDto.FullName;
            author.BirthYear = authorDto.BirthYear;
            author.Country = authorDto.Country;

            await _authorRepository.UpdateAsync(author);

            return true;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
                return false;

            await _authorRepository.DeleteAsync(id);

            return true;
        }
    }
}
