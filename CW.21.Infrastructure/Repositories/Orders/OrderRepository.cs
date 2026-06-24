using CW._21.Domain.Books;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.OrderItems;
using CW._21.Domain.Orders;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Orders;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<OrdersByCustomerDto>> GetOrdersByCustomerAsync(int customerId)
    {
        return await DbSet
            .Where(b => b.CustomerId == customerId)
            .Select(o => new OrdersByCustomerDto(o.OrderDate, o.TotalAmount, o.Status))
            .ToListAsync();
    }

    public async Task<OrderWithItemsDto?> GetOrderWithItemsAsync(int orderId)
    {
        return await DbSet
            .Where(o => o.Id == orderId)
            .Select(o => new OrderWithItemsDto(o.OrderDate, o.Customer,
                o.OrderItems.First(oi => oi.OrderId == orderId), o.OrderItems.First(oi => oi.OrderId == orderId).Book))
            .FirstOrDefaultAsync();
    }

    public async Task<List<AllOrderDto>> GetAllOrdersAsync()
    {
        return await DbSet
            .Select(o => new AllOrderDto(o.OrderDate, o.TotalAmount, o.Status, o.Customer.Fullname))
            .ToListAsync();
    }

    public async Task<List<OrderWithDetailDto>> GetOrderDetailsAsync(int orderId)
    {
        var order = await DbSet.FirstOrDefaultAsync(o => o.Id == orderId);
        var orderDetails = new List<OrderWithDetailDto>();
        foreach (var orderItem in order.OrderItems)
        {
            orderDetails.Add(new OrderWithDetailDto(orderItem.Quantity, orderItem.UnitPrice, orderItem.Book));
        }
        return orderDetails;
        
    }
}