using CW._21.Domain.Publishers;
using CW._21.Infrastructures.Repositories.Publishers;
using CW._21.Services.DTOs;

namespace CW._21.Services.Publishers;

public class PublisherService : IPublisherService
{
    private IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }
       
    
    public async Task<List<PublisherDetailDto>> GetAllPublishersWithDetails()
    {
        return await _publisherRepository.GetAllPublisherBooksDetails();
    }

    public async Task<List<PublisherBookCountDto>> GetAllPublishersWithMinimumBooks(int minimumBooks)
    {
        return await  _publisherRepository.GetAllPublishersWithMinimumBooks(minimumBooks);
    }

    public async Task<List<PublisherDetailDto>> GetAllPublisherBooksDetails()
    {
        return await _publisherRepository.GetAllPublisherBooksDetails();
    }

    public async Task<List<PublisherBookPriceDto>> GetPublisherMostExpensiveBookPrices()
    {
        return await _publisherRepository.GetPublisherMostExpensiveBookPrices();
    }
    
    public async Task<PublisherInfoDto?> GetPublisherByIdAsync(int id)
    {
        return await _publisherRepository.GetPublisherByIdAsync(id);
    }

    public async Task CreatePublisherAsync(CreatePublisherDto dto)
    {
        var publisher = new Publisher
        {
            Name = dto.Name,
            City = dto.City,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = DateTime.UtcNow
        };
        await _publisherRepository.AddAsync(publisher);
    }

    public async Task<bool> UpdatePublisherAsync(int id, UpdatePublisherDto dto)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id, tracking: true);
        if (publisher == null) return false;

        publisher.Name = dto.Name;
        publisher.City = dto.City;
        publisher.PhoneNumber = dto.PhoneNumber;

        await _publisherRepository.UpdateAsync(publisher);
        return true;
    }

    public async Task<bool> DeletePublisherAsync(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher == null) return false;

        await _publisherRepository.DeleteAsync(id);
        return true;
    }
}