using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Orders;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<OrdersByCustomerDto>> GetOrdersByCustomerAsync(int customerId);
    Task<OrderWithItemsDto?> GetOrderWithItemsAsync(int orderId);
    Task<List<AllOrderDto>> GetAllOrdersAsync();
    Task<OrderWithDetailDto?> GetOrderDetailsAsync(int orderId);
    
}