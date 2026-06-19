namespace CW._21.Domain.DTOs.Orders;

public record AllOrderDto(DateTime OrderDate, decimal TotalAmount, string OrderStatus, string CustomerName);