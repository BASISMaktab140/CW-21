using System.Linq.Expressions;
using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Repositories;
using CW21.Presentation.Repositories.Authors;
using CW21.Presentation.Repositories.Books;
using CW21.Presentation.Repositories.Categories;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;
using CW21.Presentation.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Services.Books;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;
    private ICategoryRepository _categoryRepository;
    private IAuthorRepository _authorRepository;

    
    public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository,
        IAuthorRepository authorRepository) {
        _categoryRepository = categoryRepository;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }
    public async Task<List<BookDetailDto>> GetAllBooksWithDetailsAsync()
    {
       var books = await _bookRepository.GetAll()
               .ToListAsync();
       return  books.BookDetailToDtoList();
    }

    public async Task<BookInfoDto> GetBookByIdAsync(int id)
    {
       var book = await _bookRepository.GetByIdAsync(id);
       if (book == null)
           throw new KeyNotFoundException($"Book with id {id} not found");

       return book.BookInfoToDto();
    }

    public async Task<List<BookInfoDto>> GetAvailableBooksAsync()
    {
        var books = await  _bookRepository
            .GetAll(x => x.Stock > 0)
            .ToListAsync();
            
        return  books.BookInfoToDtoList();

    }

    public async Task<List<BookInfoDto>> GetBookByTitleAsync(string title)
    {
        var result = await _bookRepository
            .GetAll(b => b.Title == title)
            .ToListAsync();
        return result.BookInfoToDtoList();
    }

    public async Task<bool> AddBookAsync(BookInfoDto bookInfo)
    {
        var book = new Book(bookInfo.Title, bookInfo.Price, bookInfo.PublishYear, bookInfo.Author.Id,
            bookInfo.Category.Id, bookInfo.Stock, bookInfo.Publisher.Id);
        await _bookRepository.AddAsync(book);
        return true;
    }

    public async Task<List<Book>?> GetBooksWithMinimumPriceAsync(int minimumQuantity)
    {
        var averagePrice = await  _bookRepository.GetAll().AverageAsync(b => b.Price);
        return await _bookRepository.GetAll()
            .Where(b => b.Stock > minimumQuantity)
            .Where(b => b.Price < averagePrice)
            .OrderByDescending(b => b.Price).ToListAsync();
    }

    public async Task<List<BookSpecsDto>> GetBookSpecsAsync()
    {
        var books = await _bookRepository
            .GetAll()
            .ToListAsync();
        
        return  books.BookSpecsToDtoList();
    }

    public async Task<List<BookInfoByTagDto>> GetBooksByTagAsync(string tagName)
    {
        var books = await _bookRepository
            .GetAll(b => b.BookTags.Any(bt => bt.Tag.Name == tagName))
            .ToListAsync();

        return books.InfoByTagToDtoList();    
    }

    public async Task<List<BookInfoByCategoryDto>> GetBooksByCategoryAsync(string categoryName)
    {
        var books = await _bookRepository
            .GetAll(b => b.Category.Name == categoryName)
            .ToListAsync();

        return books.InfoByCategoryToDtoList();
    }

    public async Task<List<BookInfoByAuthorDto>> GetBooksByAuthorAsync(string authorName)
    {
        var books = await _bookRepository
            .GetAll(b => b.Author.FullName == authorName)
            .ToListAsync();
        return books.InfoByAuthorToDtoList();
    }

    public async Task<List<BookInfoDto>> GetAuthorBooksByIdAsync(int authorId)
    {
        return await _bookRepository.GetAuthorBooksAsync(authorId);
    }

    public async Task<List<BookInfoByPublisherDto>> GetBooksByPublisherAsync(string publisherName)
    {
        var books = await _bookRepository
            .GetAll(b => b.Publisher.Name == publisherName)
            .ToListAsync();
        return books.InfoByPublisherDtoList();
    }

    public async Task<List<BookInfoByPublisherDto>> GetBooksByPriceRange(decimal minPrice, decimal maxPrice)
    {
        var books = await _bookRepository
            .GetAll(b => b.Price > minPrice && b.Price <= maxPrice)
            .ToListAsync();
        return books.InfoByPublisherDtoList();
    }

    public async Task<List<BookInfoWithPublishYearDto>> GetBooksByPublishYearAsync(int publishYear)
    {
        var books = await _bookRepository
            .GetAll(b => b.PublishYear == publishYear)
            .ToListAsync();

        return books.BookInfoWithPublishYearToDtoList();
    }

 

    public async Task<bool> UpdateBookAsync(int id, BookUpdateDto bookUpdateDto)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            throw new KeyNotFoundException($"Book with id {id} not found");

        if (bookUpdateDto.AuthorId is not null)
        {
            var author = await _authorRepository.GetByIdAsync(bookUpdateDto.AuthorId.Value);
            if (author is null)
                throw new KeyNotFoundException($"Author with id {book.AuthorId} not found");
        }

        if (bookUpdateDto.CategoryId is not null)
        {
            var category = await _categoryRepository.GetByIdAsync(bookUpdateDto.CategoryId.Value);
            if (category is null)
                throw new KeyNotFoundException($"Category with id {book.CategoryId} not found");
        }

        book.Title = bookUpdateDto.Title ?? book.Title;
        book.Price = bookUpdateDto.Price ?? book.Price;
        book.PublishYear = bookUpdateDto.PublishYear ?? book.PublishYear;
        book.AuthorId = bookUpdateDto.AuthorId ?? book.AuthorId;
        book.CategoryId = bookUpdateDto.CategoryId ?? book.CategoryId;
        book.Stock = bookUpdateDto.Stock ?? book.Stock;
        
        await _bookRepository.UpdateAsync(book);
        return true;

    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
            return false;
        await _bookRepository.DeleteAsync(book.Id);
        return true;
    }
}