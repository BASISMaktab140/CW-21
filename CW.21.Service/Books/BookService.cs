using CW._21.Domain.Books;
using CW._21.Infrastructures.Repositories.Authors;
using CW._21.Infrastructures.Repositories.Categories;
using CW._21.Services.DTOs.Books;
using CW._21.Services.Mappers;

namespace CW._21.Services.Books;

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
        return await _bookRepository.GetAllBooksWithDetailsAsync();
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
        return await _bookRepository.GetAvailableBooksAsync();
    }

    public async Task<List<BookInfoDto>> GetBookByTitleAsync(string title)
    {
        return await _bookRepository.GetBookByTitleAsync(title);
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
        return await _bookRepository.GetBooksWithMinimumPriceAsync(minimumQuantity);
    }

    public async Task<List<BookSpecsDto>> GetBookSpecsAsync()
    {
        
        return  await _bookRepository.GetBookSpecsAsync();
    }

    public async Task<List<BookInfoByTagDto>> GetBooksByTagAsync(string tagName)
    {
        
        return await _bookRepository.GetBooksByTagAsync(tagName);
    }

    public async Task<List<BookInfoByCategoryDto>> GetBooksByCategoryAsync(string categoryName)
    {
        return await _bookRepository.GetBooksByCategoryAsync(categoryName);
    }

    public async Task<List<BookInfoByAuthorDto>> GetBooksByAuthorAsync(string authorName)
    {
        return await  _bookRepository.GetBooksByAuthorAsync(authorName);
    }

    public async Task<List<BookInfoDto>> GetAuthorBooksByIdAsync(int authorId)
    {
        return await _bookRepository.GetAuthorBooksAsync(authorId);
    }

    public async Task<List<BookInfoByPublisherDto>> GetBooksByPublisherAsync(string publisherName)
    {
        return await  _bookRepository.GetBooksByPublisherAsync(publisherName);
    }

    public async Task<List<BookInfoByPublisherDto>> GetBooksByPriceRange(decimal minPrice, decimal maxPrice)
    {
       return await _bookRepository.GetBooksByPriceRange(minPrice, maxPrice);
    }

    public async Task<List<BookInfoWithPublishYearDto>> GetBooksByPublishYearAsync(int publishYear)
    {
       return await  _bookRepository.GetBooksByPublishYearAsync(publishYear);
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