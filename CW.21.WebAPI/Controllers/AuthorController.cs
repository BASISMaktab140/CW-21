using CW21.Presentation.Services.Authors;
using CW21.Presentation.Services.DTOs;
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


        public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorCreateDto authorDto)
        {
            return Ok(await _authorService.AddAuthorAsync(authorDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorUpdateDto authorDto)
        {
            return Ok(await _authorService.UpdateAuthorAsync(authorDto));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);

            if (!result)
                return NotFound();

            return Ok(result);
        }


    }
}
