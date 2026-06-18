using CW._21.Domain.DTOs;
using CW._21.Services.Publishers;
using CW._21.WebAPI.Commons;
using CW._21.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

[ApiController]
[Route("Publishers")]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var publishers = await _publisherService.GetAllPublishersWithDetails();
        return Ok(ApiResult<List<PublisherDetailDto>>.Success(publishers, "Publishers retrieved successfully"));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var publisher = await _publisherService.GetPublisherByIdAsync(id);

        if (publisher is null)
            throw new NotFoundException("Publisher", id);

        return Ok(ApiResult<PublisherInfoDto>.Success(publisher, "Publisher retrieved successfully"));
    }

    [HttpGet("details")]
    public async Task<IActionResult> GetDetailsAsync()
    {
        var details = await _publisherService.GetAllPublisherBooksDetails();
        return Ok(ApiResult<List<PublisherDetailDto>?>.Success(details, "Publisher details retrieved successfully"));
    }

    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveAsync()
    {
        var result = await _publisherService.GetPublisherMostExpensiveBookPrices();
        return Ok(ApiResult<List<PublisherBookPriceDto>?>.Success(result, "Most expensive books retrieved successfully"));
    }

    [HttpGet("minimum-books")]
    public async Task<IActionResult> GetWithMinimumBooksAsync([FromQuery] int count = 2)
    {
        var publishers = await _publisherService.GetAllPublishersWithMinimumBooks(count);
        return Ok(ApiResult<List<PublisherBookCountDto>?>.Success(publishers, "Publishers retrieved successfully"));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePublisherDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new BadRequestException("Publisher name is required.");

        await _publisherService.CreatePublisherAsync(dto);
        return StatusCode(201, ApiResult<object>.Success(null!, "Publisher created successfully", 201));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdatePublisherDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new BadRequestException("Publisher name is required.");

        var result = await _publisherService.UpdatePublisherAsync(id, dto);

        if (!result)
            throw new NotFoundException("Publisher", id);

        return Ok(ApiResult.Success("Publisher updated successfully"));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _publisherService.DeletePublisherAsync(id);

        if (!result)
            throw new NotFoundException("Publisher", id);

        return Ok(ApiResult.Success("Publisher deleted successfully"));
    }
}