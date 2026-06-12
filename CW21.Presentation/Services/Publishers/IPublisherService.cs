using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Publishers;

public interface IPublisherService
{
    Task<PublisherInfoDto?> GetPublisherByIdAsync(int id);
    Task CreatePublisherAsync(CreatePublisherDto dto);
    Task<bool> UpdatePublisherAsync(int id, UpdatePublisherDto dto);
    Task<bool> DeletePublisherAsync(int id);
    Task<List<PublisherInfoDto>> GetAllPublishersWithDetails();
    Task<List<PublisherBookCountDto>?> GetAllPublishersWithMinimumBooks(int minimumBooks);
    Task<List<PublisherDetailDto>?> GetAllPublisherBooksDetails();
    Task<List<PublisherBookPriceDto>?> GetPublisherMostExpensiveBookPrices();
}