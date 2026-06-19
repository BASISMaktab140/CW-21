using CW._21.Domain.DTOs.Books;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Books;

public interface IBookRepository : IGenericRepository<Book>
{
    
    Task<List<BookInfoDto>> GetAuthorBooksAsync(int authorId);
    Task<List<BookDetailDto>> GetAllBooksWithDetailsAsync();
    Task<List<BookInfoDto>> GetAvailableBooksAsync();
    Task<List<BookInfoDto>> GetBookByTitleAsync(string title);
    Task<List<Book>?> GetBooksWithMinimumPriceAsync(int minimumQuantity);
    Task<List<BookSpecsDto>> GetBookSpecsAsync();
    Task<List<BookInfoByTagDto>> GetBooksByTagAsync(string tagName);
    Task<List<BookInfoByCategoryDto>> GetBooksByCategoryAsync(string categoryName);
    Task<List<BookInfoByAuthorDto>> GetBooksByAuthorAsync(string authorName);
    Task<List<BookInfoByPublisherDto>> GetBooksByPublisherAsync(string publisherName);
    Task<List<BookInfoByPublisherDto>> GetBooksByPriceRange(decimal minPrice, decimal maxPrice);
    Task<List<BookInfoWithPublishYearDto>> GetBooksByPublishYearAsync(int publishYear);


}