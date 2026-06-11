using CW21.Presentation.Services.Books;
using CW21.Presentation.Services.DTOs;
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
              return Ok(await _bookService.GetAllBooksWithDetailsAsync());
       }

       [HttpGet("{id:int}")]
       public async Task<IActionResult> GetBookByIdAsync([FromRoute]int id)
       {
              var book = await _bookService.GetBookDetailsAsync(id);
              if (book == null)
                     return NotFound();
              return Ok(book);
       }

       [HttpGet("available")]
       public async Task<IActionResult> GetAvailableBooksAsync()
       {
              return Ok(await _bookService.GetAvailableBooksAsync());
       }

       [HttpGet("{title}")]
       public async Task<IActionResult> GetBookByTitleAsync([FromRoute] string title)
       {
              
              return Ok(await _bookService.GetBookByTitleAsync(title));
       }

       [HttpPost]
       public async Task<IActionResult> AddBookAsync([FromBody]BookInfoDto bookInfo)
       {
              return Ok(await _bookService.AddBookAsync(bookInfo));
       }
       
       
       
}