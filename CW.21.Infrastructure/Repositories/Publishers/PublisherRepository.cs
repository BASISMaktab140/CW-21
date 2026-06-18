using CW._21.Domain.DTOs;
using CW._21.Domain.Publishers;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Publishers;

public class PublisherRepository : GenericRepository<Publisher> , IPublisherRepository
{
    public PublisherRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<PublisherBookCountDto>> GetAllPublishersWithMinimumBooks(int minimumBooks)
    {
        return await _dbSet
            .Select(publisher =>new PublisherBookCountDto(publisher.Name,
                publisher.Books.Count())).ToListAsync();
    }

    public async Task<List<PublisherDetailDto>> GetAllPublisherBooksDetails()
    {
        return await  _dbSet
            .Select(publisher => new PublisherDetailDto(publisher.Name,
            publisher.Books.Count(),
            publisher.Books.Sum(b => b.Stock),
            publisher.Books.Any() ? publisher.Books.Average(b => b.Price) : 0)).ToListAsync();
        
    }

    public async Task<List<PublisherBookPriceDto>> GetPublisherMostExpensiveBookPrices()
    {
        return await _dbSet
            .Where(p => p.Books.Any())
            .Select(p => new
            {
                PublisherName = p.Name,
                Book = p.Books.OrderByDescending(b => b.Price).Select(b => new
                {
                    b.Price,
                    b.Title
                }).First()
            })
            .Select(p => new PublisherBookPriceDto(
                p.PublisherName,
                p.Book.Title,
                p.Book.Price)).ToListAsync();
    }

    public async Task<PublisherInfoDto?> GetPublisherByIdAsync(int id)
    {
        return await   _dbSet
            .Where(p => p.Id == id)
            .Select(publisher => new PublisherInfoDto(publisher.Name, publisher.City, publisher.Books.Count(),
            publisher.Books.Select(b => b.Title).ToList())).FirstOrDefaultAsync();
    }
}