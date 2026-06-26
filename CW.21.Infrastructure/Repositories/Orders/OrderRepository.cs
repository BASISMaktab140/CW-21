using CW._21.Domain.DTOs.Books;
using CW._21.Domain.DTOs.Orders;
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
        return await _dbSet
            .Where(b => b.CustomerId == customerId)
            .Select(o => new OrdersByCustomerDto(
                o.OrderDate, 
                o.TotalAmount, 
                o.Status))
            .ToListAsync();
    }

    public async Task<OrderWithItemsDto?> GetOrderWithItemsAsync(int orderId)
    {
        return await _dbSet
            .Where(o => o.Id == orderId)
            .Select(o => new OrderWithItemsDto(o.OrderDate, o.Customer,
                o.OrderItems.First(oi => oi.OrderId == orderId), o.OrderItems.First(oi => oi.OrderId == orderId).Book))
            .FirstOrDefaultAsync();
    }

    public async Task<List<AllOrderDto>> GetAllOrdersAsync()
    {
        return await _dbSet
            .Select(o => new AllOrderDto(o.OrderDate, o.TotalAmount, o.Status, o.Customer.Fullname))
            .ToListAsync();
    }

    public async Task<OrderWithDetailDto> GetOrderDetailsAsync(int orderId)
    {
        return await _dbSet
            .Where(o => o.Id == orderId)
            .Select(o => new OrderWithDetailDto(
                o.OrderDate,
                o.TotalAmount,
                o.Status,
                o.OrderItems.Select(b => 
                    new BookInfoByCategoryDto(b.Book.Title, 
                        b.Book.Author.FullName))
                    .ToList())).FirstOrDefaultAsync();
    }

    public Task CreateOrderAsync(int customerId, List<(int bookId, int quantity)> items)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderStatusAsync(int orderId, string status)
    {
        throw new NotImplementedException();
    }
}