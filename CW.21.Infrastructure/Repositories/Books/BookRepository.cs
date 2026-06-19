using CW._21.Domain.Books;
using CW._21.Domain.DTOs.Books;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Books;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<BookInfoDto>> GetAuthorBooksAsync(int authorId)
    {
        return await _dbSet
            .Where(b => b.AuthorId == authorId)
            .Select(b =>
                new BookInfoDto(b.Title, b.Price, b.Stock, b.PublishYear,
                    b.Author, b.Category, b.Publisher
                    , b.BookTags.Select(t => t.Tag).ToList())).ToListAsync();
    }

    public async Task<List<BookDetailDto>> GetAllBooksWithDetailsAsync()
    {
        return await _dbSet
            .Select(book => new BookDetailDto(book.Title, book.Price, book.Stock,
            book.Author.FullName, book.Category.Name,
            book.Publisher.Name, book.BookTags.Select(t => t.Tag.Name).ToList())).ToListAsync();
    }

    public async Task<List<BookInfoDto>> GetAvailableBooksAsync()
    {
        return await _dbSet
            .Where(x => x.Stock > 0)
            .Select(book => new BookInfoDto(book.Title, book.Price, book.Stock, book.PublishYear,
            book.Author, book.Category, book.Publisher
            , book.BookTags.Select(t => t.Tag).ToList())).ToListAsync();
    }

    public async Task<List<BookInfoDto>> GetBookByTitleAsync(string title)
    {
        return await _dbSet
            .Where(b => b.Title == title)
            .Select(book => new BookInfoDto(book.Title, book.Price, book.Stock, book.PublishYear,
                book.Author, book.Category, book.Publisher
                , book.BookTags.Select(t => t.Tag).ToList())).ToListAsync();
        
    }
    
    public async Task<List<Book>?> GetBooksWithMinimumPriceAsync(int minimumQuantity)
    {
        var averagePrice = await  _dbSet.AverageAsync(b => b.Price);
        return await _dbSet
            .Where(b => b.Stock > minimumQuantity)
            .Where(b => b.Price < averagePrice)
            .OrderByDescending(b => b.Price).ToListAsync();
    }

    public async Task<List<BookSpecsDto>> GetBookSpecsAsync()
    {
        return await _dbSet.
        Select(book => new BookSpecsDto(book.Title, book.Author.FullName,
            book.Category.Name, book.Publisher.Name, book.BookTags.Select(tag => tag.Tag.Name).ToList())).ToListAsync();
    }

    public async Task<List<BookInfoByTagDto>> GetBooksByTagAsync(string tagName)
    {
        return await  _dbSet
            .Select(book => new BookInfoByTagDto(
            book.Author.FullName,
            book.Title,
            book.Price)).ToListAsync();
    }

    public async Task<List<BookInfoByCategoryDto>> GetBooksByCategoryAsync(string categoryName)
    {
        return await _dbSet
            .Select(book => new BookInfoByCategoryDto(
                book.Title,
                book.Author.FullName)).ToListAsync();
    }

    public async Task<List<BookInfoByAuthorDto>> GetBooksByAuthorAsync(string authorName)
    {
        return await _dbSet
            .Select(book => new BookInfoByAuthorDto(
                book.Title,
                book.Price,
                book.Publisher.Name)).ToListAsync();
    }

    public async Task<List<BookInfoByPublisherDto>> GetBooksByPublisherAsync(string publisherName)
    {
        return await _dbSet
            .Select(book => new BookInfoByPublisherDto(
                book.Title,
                book.Price,
                book.Publisher.Name)).ToListAsync();
    }

    public async Task<List<BookInfoByPublisherDto>> GetBooksByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await _dbSet
            .Where(b => b.Price > minPrice && b.Price <= maxPrice)
            .Select(book => new BookInfoByPublisherDto(
                book.Title,
                book.Price,
                book.Publisher.Name)).ToListAsync();
    }

    public async Task<List<BookInfoWithPublishYearDto>> GetBooksByPublishYearAsync(int publishYear)
    {
        return await _dbSet
            .Where(b => b.PublishYear == publishYear)
            .Select(book => new BookInfoWithPublishYearDto(
            book.Title,
            book.PublishYear)).ToListAsync();
        
    }
}