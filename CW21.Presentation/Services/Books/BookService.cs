using System.Linq.Expressions;
using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Repositories;
using CW21.Presentation.Repositories.Books;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Services.Books;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository) {
        _bookRepository = bookRepository;
    }
    public async Task<List<BookDetailDto>?> GetAllBooksWithDetailsAsync()
    {
       return await _bookRepository.GetAll()
               .Include(x => x.Author)
               .Include(x => x.Category)
               .Include(x => x.Publisher)
               .Include(x => x.BookTags)
               .Select(x => x.BookDetailMapper()).ToListAsync();
    }

    public async Task<BookInfoDto?> GetBookDetailsAsync(int id)
    {
       var book = await _bookRepository.GetByIdAsync(id);
       if (book == null)
           throw new KeyNotFoundException($"Book with id {id} not found");

       return book.BookInfoMapper();
    }

    public async Task<List<BookInfoDto>> GetAvailableBooksAsync()
    {
        var result = await _bookRepository.GetAll(x => x.Stock > 0)
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Include(x => x.Publisher)
            .Include(x => x.BookTags)
            .Select(book => book.BookInfoMapper())
            .ToListAsync();
        return result;

    }

    public async Task<List<BookInfoDto>> GetBookByTitleAsync(string title)
    {
        var result = await _bookRepository.GetAll(b => b.Title == title)
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Include(x => x.Publisher)
            .Include(x => x.BookTags)
            .Select(book => book.BookInfoMapper())
            .ToListAsync();
        return result;
    }

    public async Task<bool> AddBookAsync(BookInfoDto bookInfo)
    {
        var book = new Book(bookInfo.Title, bookInfo.Price, bookInfo.PublishYear, bookInfo.Author.Id,
            bookInfo.Category.Id, bookInfo.Stock, bookInfo.Publisher.Id);
        await _bookRepository.AddAsync(book);
        return true;
    }

    public async Task<List<Book>?> GetBooksMeetCriteria(int minimumQuantity)
    {
        var averagePrice = _bookRepository.GetAll().Average(b => b.Price);
        return await _bookRepository.GetAll()
            .Where(b => b.Stock > minimumQuantity)
            .Where(b => b.Price < averagePrice)
            .OrderByDescending(b => b.Price).ToListAsync();
    }
}