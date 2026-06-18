using CW._21.Domain.DTOs;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Publishers;

public interface IPublisherRepository : IGenericRepository<Publisher>
{
    Task<List<PublisherBookCountDto>> GetAllPublishersWithMinimumBooks(int minimumBooks);
    Task<List<PublisherDetailDto>> GetAllPublisherBooksDetails();
    Task<List<PublisherBookPriceDto>> GetPublisherMostExpensiveBookPrices();
    Task<PublisherInfoDto?> GetPublisherByIdAsync(int id);
}