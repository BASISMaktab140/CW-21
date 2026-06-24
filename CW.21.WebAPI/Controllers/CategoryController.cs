using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Categories;
using CW._21.Domain.Exceptions;
using CW._21.Services.Categories;
using CW._21.WebAPI.Commons;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

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
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(ApiResult<List<CategoryDetailDto>>.Success(categories, "Categories retrieved successfully"));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);

        if (category == null)
            throw new NotFoundException("Category", id);

        return Ok(ApiResult<CategoryDetailDto>.Success(category, "Category retrieved successfully"));
    }

    [HttpGet("availableStock")]
    public async Task<IActionResult> GetCategoriesWithAvailableStockAsync()
    {
        var categories = await _categoryService.GetCategoriesWithAvailableStockAsync();
        return Ok(ApiResult<List<CategoryDetailDto>>.Success(categories, "Categories retrieved successfully"));
    }

    [HttpGet("bookCount")]
    public async Task<IActionResult> GetCategoriesWithBookCountAsync()
    {
        var categories = await _categoryService.GetCategoriesWithBookCountAsync();
        return Ok(ApiResult<List<CategoryWithCountDto>>.Success(categories, "Category book counts retrieved successfully"));
    }
}