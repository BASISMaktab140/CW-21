using CW._21.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers
{
    [ApiController]
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }
        

        [HttpGet("availableStock")]
        public async Task<IActionResult> GetCategoriesWithAvailableStockAsync()
        {
            return Ok(await _categoryService.GetCategoriesWithAvailableStockAsync());
        }

        [HttpGet("bookCount")]
        public async Task<IActionResult> GetCategoriesWithBookCountAsync()
        {
            return Ok(await _categoryService.GetCategoriesWithBookCountAsync());
        }
    }
}
