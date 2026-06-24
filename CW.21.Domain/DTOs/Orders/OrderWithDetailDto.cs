using CW._21.Domain.Books;

namespace CW._21.Domain.DTOs.Orders;

public record OrderWithDetailDto(int Quantity, decimal UnitPrice, Book Book);