namespace CW21.Presentation.Services.DTOs;

public record BookUpdateDto(string? Title, decimal? Price, int? PublishYear, int? AuthorId, int? CategoryId, int? Stock);