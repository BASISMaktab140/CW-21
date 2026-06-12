using CW21.Presentation.Services.DTOs;
using CW21.Presentation.Services.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

public class PublisherController
{
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
            => Ok(await _publisherService.GetAllPublishersWithDetails());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var publisher = await _publisherService.GetPublisherByIdAsync(id);
            return publisher is null ? NotFound() : Ok(publisher);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetailsAsync()
            => Ok(await _publisherService.GetAllPublisherBooksDetails());

        [HttpGet("most-expensive")]
        public async Task<IActionResult> GetMostExpensiveAsync()
            => Ok(await _publisherService.GetPublisherMostExpensiveBookPrices());

        [HttpGet("minimum-books")]
        public async Task<IActionResult> GetWithMinimumBooksAsync([FromQuery] int count = 2)
            => Ok(await _publisherService.GetAllPublishersWithMinimumBooks(count));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePublisherDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _publisherService.CreatePublisherAsync(dto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdatePublisherDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _publisherService.UpdatePublisherAsync(id, dto);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = await _publisherService.DeletePublisherAsync(id);
            return result ? Ok() : NotFound();
        }
    }
}