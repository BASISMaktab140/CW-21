using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Exceptions;
using CW._21.Services.Orders;
using CW._21.WebAPI.Commons;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

[ApiController]
[Route("Orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpGet("api/Orders")]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(ApiResult<List<AllOrderDto>>.Success(orders, "Orders retrieved successfully"));
    }

    [HttpGet("api/Orders/{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute]int id)
    {
        var order = await _orderService.GetOrderDetailsAsync(id);
        return Ok(ApiResult<OrderWithDetailDto>.Success(order, "Order retrieved successfully"));
    }

    [HttpGet("api/Orders/customer/{customerId} ")]
    public async Task<IActionResult> GetOrdersByCustomerId([FromRoute]int customerId)
    {
        var customerOrder = await _orderService.GetCustomerOrdersAsync(customerId);
        return Ok(ApiResult<List<OrdersByCustomerDto>>.Success(customerOrder, "Orders retrieved successfully"));
    }

    [HttpPost("api/Orders")]
    public async Task<IActionResult> CreateNewOrder([FromBody]int customerId, [FromBody]List<(int bookId, int quantity)> orderDetails)
    {
        await _orderService.CreateOrderAsync(customerId, orderDetails);
        
        foreach (var orderDetail in orderDetails)
            if (orderDetail.quantity == 0)
                throw new BadRequestException("You Picked No Book.");
        
        return StatusCode(201, ApiResult<object>.Success(null!, "Order created successfully", 201));
    }

    [HttpPut("api/Orders/{id}/status")]
    public async Task<IActionResult> UpdateOrderStatus([FromRoute] int id, [FromBody] string status)
    {
        await _orderService.UpdateOrderStatusAsync(id, status);
        return StatusCode(200, ApiResult<object>.Success(null!, "Order status updated successfully", 201));
    }
}