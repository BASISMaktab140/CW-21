using System.Runtime.InteropServices.JavaScript;
using CW._21.Domain.Books;
using CW._21.Domain.DTOs.OrderItems;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.OrderItems;
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

    public async Task<List<AllOrderDto>> GetAllOrdersAsync()
    {
       return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task<OrderWithDetailDto> GetOrderDetailsAsync(int orderId)
    {
        return await  _orderRepository.GetOrderDetailsAsync(orderId); 
    }

    public async Task<List<OrdersByCustomerDto>> GetCustomerOrdersAsync(int customerId)
    {
        return await _orderRepository.GetOrdersByCustomerAsync(customerId);
    }



    public async Task UpdateOrderStatusAsync(int orderId, string status)
    {
        var order =  await _orderRepository.GetByIdAsync(orderId);
        if(order is  null)
            throw new Exception("Order not found");
        
        order.Status = status;
        await _orderRepository.UpdateAsync(order);
    }
    

    public async Task CreateOrderAsync(int customerId, List<OrderItemBasicDto> items)
    {
        var order = new Order
        (
            customerId,
             DateTime.UtcNow,
             "Pending",
              new List<OrderItem>());

        decimal totalAmount = 0;
        foreach (var item in items)
        {
            var book = await _bookRepository.GetByIdAsync(item.bookId) ??
                       throw new Exception($"Book with id {item.bookId} does not exist");
            if(book.Stock > item.quantity)
                throw new Exception($"not enough stock for book '{item.bookId}'");
            book.Stock -= item.quantity;

            var unitPrice = book.Price;
            
            order.OrderItems.Add(new OrderItem(book.Id,item.quantity, unitPrice));
            
            totalAmount += item.quantity * unitPrice;

        }

        order.TotalAmount = totalAmount;
        await _orderRepository.AddAsync(order);

    }
    
}