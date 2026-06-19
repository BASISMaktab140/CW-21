namespace CW._21.Domain.DTOs.Orders;

public record OrdersByCustomerDto(DateTime OrderDate, decimal TotalAmount, string Status);


