using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Tags;
using CW._21.Services.Tags;
using CW._21.WebAPI.Commons;
using CW._21.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

[ApiController]
[Route("Tags")]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTagsAsync(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        if (pageNumber < 1)
            throw new BadRequestException("Page number must be greater than 0.");

        var skip = (pageNumber - 1) * pageSize;
        var tags = await _tagService.GetAllTagsAsync(skip, pageSize);
        return Ok(ApiResult<List<TagInfoDto>>.Success(tags, "Tags retrieved successfully"));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTagByIdAsync([FromRoute] int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);

        if (tag == null)
            throw new NotFoundException("Tag", id);

        return Ok(ApiResult<TagInfoDto>.Success(tag, "Tag retrieved successfully"));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTagAsync([FromBody] CreateTagDto tagDto)
    {
        if (string.IsNullOrWhiteSpace(tagDto.Name))
            throw new BadRequestException("Tag name is required.");

        await _tagService.CreateTagAsync(tagDto.Name);
        return StatusCode(201, ApiResult<object>.Success(null!, "Tag created successfully", 201));
    }

    [HttpPost("{id:int}/Books")]
    public async Task<IActionResult> AddTagToBookAsync([FromRoute] int id, [FromBody] int bookId)
    {
        await _tagService.AddTagToBookAsync(id, bookId);
        return Ok(ApiResult.Success("Tag added to book successfully"));
    }

    [HttpDelete("{id:int}/Books")]
    public async Task<IActionResult> RemoveTagFromBookAsync([FromRoute] int id, [FromBody] int bookId)
    {
        await _tagService.RemoveTagFromBookAsync(id, bookId);
        return Ok(ApiResult.Success("Tag removed from book successfully"));
    }
}