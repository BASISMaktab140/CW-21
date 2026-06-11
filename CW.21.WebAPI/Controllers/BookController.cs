using CW21.Presentation.Services.Books;
using CW21.Presentation.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using CW21.Presentation.Commons;

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

       // 1
       [HttpGet]
       public async Task<IActionResult> GetBooksAsync()
       {
              var books = await _bookService.GetAllBooksWithDetailsAsync();
              return Ok(ApiResult<List<BookDetailDto>>.Success(books, "Books retrieved successfully"));
       }

       // 2
       [HttpGet("{id:int}")]
       public async Task<IActionResult> GetBookByIdAsync([FromRoute]int id)
       {
              var book = await _bookService.GetBookByIdAsync(id);
              if (book == null)
                     return NotFound();
              return Ok(book);
       }
       // 3
       [HttpGet("available")]
       public async Task<IActionResult> GetAvailableBooksAsync()
       {
              return Ok(await _bookService.GetAvailableBooksAsync());
       }

       // 4
       [HttpGet("{title}")]
       public async Task<IActionResult> GetBookByTitleAsync([FromRoute] string title)
       {
              
              return Ok(await _bookService.GetBookByTitleAsync(title));
       }
       
       // 0
       [HttpPost]
       public async Task<IActionResult> AddBookAsync([FromBody]BookInfoDto bookInfo)
       {
              return Ok(await _bookService.AddBookAsync(bookInfo));
       }
       
       // 5
       [HttpGet("category/{category}")]
       public async Task<IActionResult> GetBooksByCategoryAsync([FromRoute] string category)
       {
              return Ok(await _bookService.GetBooksByCategoryAsync(category));
       }
       
       
       // 6
       [HttpGet("author/{author}")]
       public async Task<IActionResult> GetBooksByAuthorAsync([FromRoute] string author)
       {
              return Ok(await _bookService.GetBooksByAuthorAsync(author));
       }
       
       // 7
       [HttpGet("publisher/{publisher}")]
       public async Task<IActionResult> GetBooksByPublisherAsync([FromRoute] string publisher)
       {
              return Ok(await _bookService.GetBooksByPublisherAsync(publisher));
       }
       
       // 8
       [HttpGet("tag/{tag}")]
       public async Task<IActionResult> GetBooksByTagAsync([FromRoute] string tag)
       {
              return Ok(await _bookService.GetBooksByTagAsync(tag));
       }
       // 9
       [HttpGet("{minimumPrice:int}/{maximumPrice:int}")]
       public async Task<IActionResult> GetBooksByPriceRangeAsync([FromQuery] decimal minimumPrice
              , [FromQuery] decimal maximumPrice)
       {
              return Ok(await _bookService.GetBooksByPriceRange(minimumPrice, maximumPrice));
       }
       
       // 10
       [HttpGet("publishYear/{publishYear:int}")]
       public async Task<IActionResult> GetBooksByPublishYearAsync([FromRoute] int publishYear)
       {
              return Ok(await _bookService.GetBooksByPublishYearAsync(publishYear));
       }
       
       // 11
       [HttpDelete("{id:int}/")]
       public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
       {
              var result = await _bookService.DeleteBookAsync(id);
              if (!result)
                     return NotFound(); 
              return Ok();
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] BookUpdateDto bookUpdateDto)
       {
              var result = await _bookService.UpdateBookAsync(id, bookUpdateDto);
              if (!result)
                     return NotFound();
              return Ok();
       }
}