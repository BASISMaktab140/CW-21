using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Publishers;

namespace CW._21.Services.Publishers;

public interface IPublisherService
{
    Task<PublisherInfoDto?> GetPublisherByIdAsync(int id);
    Task CreatePublisherAsync(CreatePublisherDto dto);
    Task<bool> UpdatePublisherAsync(int id, UpdatePublisherDto dto);
    Task<bool> DeletePublisherAsync(int id);
    Task<List<PublisherDetailDto>> GetAllPublishersWithDetails();
    Task<List<PublisherBookCountDto>?> GetAllPublishersWithMinimumBooks(int minimumBooks);
    Task<List<PublisherDetailDto>?> GetAllPublisherBooksDetails();
    Task<List<PublisherBookPriceDto>?> GetPublisherMostExpensiveBookPrices();
}