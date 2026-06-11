using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Publishers;
using CW21.Presentation.Repositories.Books;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Repositories.Publishers;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Services.Publishers;

public class PublisherService : IPublisherService
{
    private IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }
       
    
    public async Task<List<PublisherInfoDto>> GetAllPublishersWithDetails()
    {
        return await _publisherRepository.GetAll()
            .Include(x => x.Books)
            .Select(x => x.PublisherDetailMapper())
            .ToListAsync();
    }

    public async Task<List<PublisherBookCountDto>?> GetAllPublishersWithMinimumBooks(int minimumBooks)
    {
        return await  _publisherRepository.GetAll()
            .Include(x => x.Books)
            .Where(x => x.Books.Count() > minimumBooks)
            .Select(p => p.PublisherBookCountMapper())
            .ToListAsync();
    }

    public async Task<List<PublisherDetailDto>?> GetAllPublisherBooksDetails()
    {
        return await _publisherRepository.GetAll()
            .Include(x => x.Books)
            .Select(p => p.PublisherBookDetailDtoMapper())
            .ToListAsync();
    }

    public async Task<List<PublisherBookPriceDto>?> GetPublisherMostExpensiveBookPrices()
    {
        return await _publisherRepository.GetAll()
            .Include(x => x.Books)
            .Select(x => x.PublisherBookPriceDtoMapper())
            .ToListAsync();
    }
}