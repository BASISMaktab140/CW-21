namespace CW21.Presentation.Services.DTOs;

public record PublisherDetailDto(string  PublisherName, int BookCount, int TotalStock, decimal AveragePrice);