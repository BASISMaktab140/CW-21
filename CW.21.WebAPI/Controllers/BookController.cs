using CW._21.Domain.DTOs.Books;
using CW._21.Domain.Exceptions;
using CW._21.Services.Books;
using CW._21.WebAPI.Commons;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

[ApiController]
[Route("Books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooksAsync()
    {
        var books = await _bookService.GetAllBooksWithDetailsAsync();
        return Ok(ApiResult<List<BookDetailDto>>
            .Success(books, "Books retrieved successfully"));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBookByIdAsync([FromRoute] int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return Ok(ApiResult<BookInfoDto>
            .Success(book, "Book retrieved successfully"));
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableBooksAsync()
    {
        var books = await _bookService.GetAvailableBooksAsync();
        return Ok(ApiResult<List<BookInfoDto>>.Success(books, "Available books retrieved successfully"));
    }

    [HttpGet("{title}")]
    public async Task<IActionResult> GetBookByTitleAsync([FromRoute] string title)
    {
        var books = await _bookService.GetBookByTitleAsync(title);
        return Ok(ApiResult<List<BookInfoDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpPost]
    public async Task<IActionResult> AddBookAsync([FromBody] BookInfoDto bookInfo)
    {
        if (string.IsNullOrWhiteSpace(bookInfo.Title))
            throw new BadRequestException("Book title is required.");

        var result = await _bookService.AddBookAsync(bookInfo);

        if (!result)
            throw new BadRequestException("Failed to add book. Please check the provided data.");

        return StatusCode(201, ApiResult<object>.Success(null!, "Book created successfully", 201));
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetBooksByCategoryAsync([FromRoute] string category)
    {
        var books = await _bookService.GetBooksByCategoryAsync(category);
        return Ok(ApiResult<List<BookInfoByCategoryDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpGet("author/{author}")]
    public async Task<IActionResult> GetBooksByAuthorAsync([FromRoute] string author)
    {
        var books = await _bookService.GetBooksByAuthorAsync(author);
        return Ok(ApiResult<List<BookInfoByAuthorDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpGet("{id:int}/books")]
    public async Task<IActionResult> GetAuthorBooksAsync(int id)
    {
        var books = await _bookService.GetAuthorBooksByIdAsync(id);
        return Ok(ApiResult<List<BookInfoDto>>.Success(books, "Author books retrieved successfully"));
    }

    [HttpGet("publisher/{publisher}")]
    public async Task<IActionResult> GetBooksByPublisherAsync([FromRoute] string publisher)
    {
        var books = await _bookService.GetBooksByPublisherAsync(publisher);
        return Ok(ApiResult<List<BookInfoByPublisherDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpGet("tag/{tag}")]
    public async Task<IActionResult> GetBooksByTagAsync([FromRoute] string tag)
    {
        var books = await _bookService.GetBooksByTagAsync(tag);
        return Ok(ApiResult<List<BookInfoByTagDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpGet("{minimumPrice:int}/{maximumPrice:int}")]
    public async Task<IActionResult> GetBooksByPriceRangeAsync([FromRoute] int minimumPrice, [FromRoute] int maximumPrice)
    {
        if (minimumPrice > maximumPrice)
            throw new BadRequestException("Minimum price cannot be greater than maximum price.");

        var books = await _bookService.GetBooksByPriceRange(minimumPrice, maximumPrice);
        return Ok(ApiResult<List<BookInfoByPublisherDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpGet("publishYear/{publishYear:int}")]
    public async Task<IActionResult> GetBooksByPublishYearAsync([FromRoute] int publishYear)
    {
        var books = await _bookService.GetBooksByPublishYearAsync(publishYear);
        return Ok(ApiResult<List<BookInfoWithPublishYearDto>>.Success(books, "Books retrieved successfully"));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
    {
        var result = await _bookService.DeleteBookAsync(id);

        if (!result)
            throw new NotFoundException("Book", id);

        return Ok(ApiResult.Success("Book deleted successfully"));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] BookUpdateDto bookUpdateDto)
    {
        var result = await _bookService.UpdateBookAsync(id, bookUpdateDto);

        if (!result)
            throw new NotFoundException("Book", id);

        return Ok(ApiResult.Success("Book updated successfully"));
    }
}