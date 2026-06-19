using CW._21.Domain.Books;
using CW._21.Domain.Customers;
using CW._21.Domain.OrderItems;

namespace CW._21.Domain.DTOs.Orders;

public record OrderWithItemsDto(DateTime OrderDate, Customer Customer, OrderItem OrderItem, Book Book);