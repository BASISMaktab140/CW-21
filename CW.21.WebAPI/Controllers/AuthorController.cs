using CW._21.Services.Authors;
using CW._21.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers
{
    [ApiController]
    [Route("Authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpGet("more-than-two-books")]
        public async Task<IActionResult> GetAuthorsWithMoreThanTwoBooksAsync()
        {
            return Ok(await _authorService.GetAuthorsWithMoreThanTwoBooksAsync());
        }


        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchAuthorByNameAsync(string name)
        {
            return Ok(await _authorService.SearchAuthorByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorCreateDto authorDto)
        {
            await _authorService.AddAuthorAsync(authorDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorUpdateDto authorDto)
        {
            await _authorService.UpdateAuthorAsync(authorDto);
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return Ok();
        }
    }
}