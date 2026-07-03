using CW._21.Domain.DTOs.OrderItems;
using CW._21.Domain.DTOs.Orders;

namespace CW._21.Services.Orders;

public interface IOrderService
{
    Task<List<AllOrderDto>> GetAllOrdersAsync();
    Task<OrderWithDetailDto> GetOrderDetailsAsync(int orderId);
    
    // TODO Rewrite method
    void GetCustomerOrdersAsync(string customerId);
    Task UpdateOrderStatusAsync(int orderId, string status);

    Task CreateOrderAsync(string customerId, List<OrderItemBasicDto> items);
}