namespace CW._21.Services.DTOs.Books;

public record BookUpdateDto(string? Title, decimal? Price, int? PublishYear, int? AuthorId, int? CategoryId, int? Stock);