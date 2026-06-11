using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Tags;

namespace CW21.Presentation.Services.DTOs;


public record BookDetailDto(string Title,decimal Price, int Stock, 
    string AuthorName,string CategoryName,
    string PublisherName, List<string> Tags);

public static class BookMapper
{
    public static BookDetailDto BookDetailMapper(this Book book)
    {
        return new BookDetailDto(book.Title,book.Price, book.Stock,
            book.Author.FullName, book.Category.Name, 
            book.Publisher.Name, book.BookTags.Select(tag => tag.Tag.Name).ToList());
    }

    public static BookInfoDto BookInfoMapper(this Book book)
    {
        return new BookInfoDto(book.Title, book.Price, book.Stock, book.PublishYear,
            book.Author , book.Category,book.Publisher
        , book.BookTags.Select(tag => tag.Tag).ToList());
    }
}

