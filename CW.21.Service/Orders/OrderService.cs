using System.Runtime.InteropServices.JavaScript;
using CW._21.Domain.Books;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Orders;

namespace CW._21.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBookRepository _bookRepository;
    

    public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
    }

    public Task<AllOrderDto> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderWithDetailDto> GetOrderDetailsAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrdersByCustomerDto>> GetCustomerOrdersAsync(int customerId)
    {
        return await _orderRepository.GetOrdersByCustomerAsync(customerId);
    }

    // public async Task CreateOrderAsync(int customerId, List<(int bookId, int quantity)> items)
    // {
    //     var book = await _bookRepository.GetByIdAsync(items.First().bookId);
    //     if (book == null)
    //         throw new Exception("Book not found");
    //     if (items.Where()(i =>i.quantity < book.Stock))
    //         throw new Exception("Not enough stock");
    //     await _orderRepository.CreateOrderAsync(customerId, items);
    // }

    public Task UpdateOrderStatusAsync(int orderId, string status)
    {
        throw new NotImplementedException();
    }
}