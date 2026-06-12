using System.ComponentModel.DataAnnotations;
using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Publishers;

namespace CW21.Presentation.Services.DTOs;

public record PublisherInfoDto(
    string PublisherName,
    string PublisherCity,
    int PublisherBooks,
    List<string> BookNames);

public record CreatePublisherDto(
    [property: Required]
    [property: MaxLength(100)]
    string Name,
    [property: MaxLength(50)] string? City,
    [property: MaxLength(20)] string? PhoneNumber);

public record UpdatePublisherDto(
    [property: Required]
    [property: MaxLength(100)]
    string Name,
    [property: MaxLength(50)] string? City,
    [property: MaxLength(20)] string? PhoneNumber);

public static class PublisherMapper
{
    public static PublisherInfoDto PublisherDetailMapper(this Publisher publisher)
    {
        return new PublisherInfoDto(publisher.Name, publisher.City, publisher.Books.Count(),
            publisher.Books.Select(b => b.Title).ToList());
    }

    public static PublisherBookCountDto PublisherBookCountMapper(this Publisher publisher)
    {
        return new PublisherBookCountDto(publisher.Name, publisher.Books.Count());
    }

    public static PublisherDetailDto PublisherBookDetailDtoMapper(this Publisher publisher)
    {
        return new PublisherDetailDto(publisher.Name,
            publisher.Books.Count(),
            publisher.Books.Sum(b => b.Stock),
            publisher.Books.Any() ? publisher.Books.Average(b => b.Price) : 0);
    }

    public static PublisherBookPriceDto PublisherBookPriceDtoMapper(this Publisher publisher)
    {
        if (!publisher.Books.Any())
        {
            return new PublisherBookPriceDto(publisher.Name, "No books", 0);
        }

        var mostExpensiveBook = publisher.Books.OrderByDescending(b => b.Price).First();
        return new PublisherBookPriceDto(publisher.Name, mostExpensiveBook.Title, mostExpensiveBook.Price);
    }
}