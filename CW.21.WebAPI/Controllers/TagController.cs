using System.ComponentModel.DataAnnotations;
using CW._21.Domain.Tags;
using CW._21.Services.DTOs;
using CW._21.Services.DTOs.Books;
using CW._21.Services.Tags;
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

    [HttpGet()]
    public async Task<ActionResult<List<Tag>>> GetAllTagsAsync(
        [FromQuery][Range(1d,10d)] int pageNumber = 1, 
        [FromQuery] int pageSize = 10)
    {
        var skip = (pageNumber - 1) * 10;
        var tags = await _tagService.GetAllTagsAsync(skip, pageSize);
        return Ok(tags);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tag>> GetTagByIdAsync([FromRoute] int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        
        if (tag == null)
            return NotFound();
        
        return Ok(tag);
    }

    [HttpPost()]
    public async Task<ActionResult<Tag>> CreateTagAsync([FromBody] CreateTagDto tagDto)
    {
        var result = _tagService.CreateTagAsync(tagDto.Name);
        return Ok(result);
    }
    

    [HttpPost("{id:int}/Books")]
    public async Task<ActionResult> AddTagToBookAsync([FromRoute] int tagId,
        [FromBody] int bookId)
    {
         await _tagService.AddTagToBookAsync(tagId, bookId);
         return Ok();
    }

    [HttpDelete("{id:int}/Books")]
    public async Task<ActionResult> RemoveTagFromBookAsync([FromRoute] int tagId,
        [FromBody] int bookId)
    {
        await _tagService.RemoveTagFromBookAsync(tagId, bookId);
        return Ok();
    }
    
}