using CW._21.Domain.Books;
using CW._21.Domain.DTOs.Books;

namespace CW._21.Domain.DTOs.Orders;

public record OrderWithDetailDto(DateTime OrderDate, 
    decimal TotalAmount, string Status, List<BookInfoByCategoryDto> Books);