using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Authors;
using CW._21.Services.Authors;
using CW._21.WebAPI.Commons;
using CW._21.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

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
        var authors = await _authorService.GetAllAuthorsAsync();
        return Ok(ApiResult<List<AuthorBookCountDto>>.Success(authors, "Authors retrieved successfully"));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthorByIdAsync(int id)
    {
        var author = await _authorService.GetAuthorByIdAsync(id);

        if (author == null)
            throw new NotFoundException("Author", id);

        return Ok(ApiResult<AuthorInfoDto>.Success(author, "Author retrieved successfully"));
    }

    [HttpGet("more-than-two-books")]
    public async Task<IActionResult> GetAuthorsWithMoreThanTwoBooksAsync()
    {
        var authors = await _authorService.GetAuthorsWithMoreThanTwoBooksAsync();
        return Ok(ApiResult<List<AuthorInfoDto>>.Success(authors, "Authors retrieved successfully"));
    }

    [HttpGet("search/{name}")]
    public async Task<IActionResult> SearchAuthorByNameAsync(string name)
    {
        var authors = await _authorService.SearchAuthorByNameAsync(name);
        return Ok(ApiResult<List<AuthorInfoDto>>.Success(authors, $"Search results for '{name}'"));
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorCreateDto authorDto)
    {
        if (string.IsNullOrWhiteSpace(authorDto.FullName))
            throw new BadRequestException("Author full name is required.");

        await _authorService.AddAuthorAsync(authorDto);

        return StatusCode(201, ApiResult<object>.Success(null!, "Author created successfully", 201));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorUpdateDto authorDto)
    {
        await _authorService.UpdateAuthorAsync(authorDto);
        return Ok(ApiResult.Success("Author updated successfully"));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthorAsync(int id)
    {
        await _authorService.DeleteAuthorAsync(id);
        return Ok(ApiResult.Success("Author deleted successfully"));
    }
}