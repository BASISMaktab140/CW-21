using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Publishers;

public interface IPublisherService
{
    Task<List<PublisherInfoDto>> GetAllPublishersWithDetails();
    Task<List<PublisherBookCountDto>?> GetAllPublishersWithMinimumBooks(int minimumBooks);
    Task<List<PublisherDetailDto>?> GetAllPublisherBooksDetails();
    Task<List<PublisherBookPriceDto>?> GetPublisherMostExpensiveBookPrices();
}