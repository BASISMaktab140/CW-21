using CW._21.Domain.Publishers;
using CW._21.Infrastructures.Repositories.Generics;
using CW._21.Services.DTOs;

namespace CW._21.Infrastructures.Repositories.Publishers;

public interface IPublisherRepository : IGenericRepository<Publisher>
{
    Task<List<PublisherBookCountDto>> GetAllPublishersWithMinimumBooks(int minimumBooks);
    Task<List<PublisherDetailDto>> GetAllPublisherBooksDetails();
    Task<List<PublisherBookPriceDto>> GetPublisherMostExpensiveBookPrices();
    Task<PublisherInfoDto?> GetPublisherByIdAsync(int id);
}