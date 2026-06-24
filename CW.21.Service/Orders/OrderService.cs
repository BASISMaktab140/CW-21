using System.Runtime.InteropServices.JavaScript;
using CW._21.Domain.Books;
using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.OrderItems;
using CW._21.Domain.Orders;

namespace CW._21.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;


    public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public async Task<List<AllOrderDto>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }

    public Task<OrderWithDetailDto> GetOrderDetailsAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrdersByCustomerDto>> GetCustomerOrdersAsync(int customerId)
    {
        return await _orderRepository.GetOrdersByCustomerAsync(customerId);
    }

    public async Task CreateOrderAsync(int customerId, List<(int bookId, int quantity)> items)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId) ??
                       throw new Exception($"Customer {customerId} You must sign in first");
        decimal totalAmount = 0;
        var order = new Order
        (
            customerId,
            DateTime.UtcNow,
            totalAmount,
            "Pending",
            customer);

        foreach (var item in items)
        {
            var book = await _bookRepository.GetByIdAsync(item.bookId) ??
                       throw new Exception($"Book with id {item.bookId} does not exist");
            if (book.Stock > item.quantity)
                throw new Exception($"not enough stock for book '{item.bookId}'");
            book.Stock -= item.quantity;

            var unitPrice = book.Price;

            order.OrderItems.Add(new OrderItem(order.Id, book.Id, item.quantity, unitPrice, order, book));
            totalAmount += item.quantity * unitPrice;
        }

        order.TotalAmount = totalAmount;
        await _orderRepository.AddAsync(order);
    }

    public async Task UpdateOrderStatusAsync(int orderId, string status)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new Exception("Order not found");
        order.Status = status;
        await _orderRepository.UpdateAsync(order);
    }
}