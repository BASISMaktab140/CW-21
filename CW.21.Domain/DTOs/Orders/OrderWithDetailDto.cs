using CW._21.Domain.Books;

namespace CW._21.Domain.DTOs.Orders;

public record OrderWithDetailDto(DateTime Orderdate, decimal TotalAmount, string Status, List<Book> Books);