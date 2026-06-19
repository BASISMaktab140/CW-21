namespace CW._21.Domain.DTOs.Publishers;

public record PublisherBookPriceDto(string PublisherName, string? BookTitle, decimal? Price);