namespace CW._21.Domain.DTOs.Publishers;

public record PublisherDetailDto(string  PublisherName, int BookCount, int TotalStock, decimal AveragePrice);