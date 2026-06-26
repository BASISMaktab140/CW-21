using CW._21.Domain.DTOs.OrderItems;

namespace CW._21.Domain.DTOs.Orders;

public record CreateOrderRequestDto(int CustomerId, List<OrderItemBasicDto> OrderItems);