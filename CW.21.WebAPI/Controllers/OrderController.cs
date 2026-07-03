using CW._21.Domain.DTOs.OrderItems;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Orders;
using CW._21.Services.Orders;
using CW._21.WebAPI.Commons;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

[ApiController]
[Route("api/Orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    

   public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(ApiResult<List<AllOrderDto>>
            .Success(orders, "Orders retrieved successfully."));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrderAsync([FromRoute] int id)
    {
        var order = await _orderService
            .GetOrderDetailsAsync(id);
        return Ok(ApiResult<OrderWithDetailDto>
            .Success(order, "Order Details retrieved successfully."));
    }

    [HttpGet("/customer/{id:int}")]
    public async Task<IActionResult> GetCustomerOrdersAsync([FromRoute] string id)
    {
        /*var orders = await _orderService
            .GetCustomerOrdersAsync(id);
        
        return Ok(ApiResult<List<OrdersByCustomerDto>>
            .Success(orders, "Orders retrieved successfully."));*/
        
        return Ok();    
    }

    [HttpPost]
    public async Task<IActionResult> AddOrderAsync([FromBody] CreateOrderRequestDto createOrderRequestDto)
    {
        if (createOrderRequestDto.OrderItems is null || !createOrderRequestDto.OrderItems.Any())
            return BadRequest("Order must contain at least one item.");

         /*
         await _orderService
             .CreateOrderAsync(createOrderRequestDto.CustomerId, createOrderRequestDto.OrderItems);
             */
         
         return StatusCode(201, ApiResult<object>.Success(null!, "Order created successfully", 201));

    }
}