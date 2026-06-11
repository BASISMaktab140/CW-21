using CW21.Presentation.Entities.Books;
using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Mappers;

public static class BookMapper
{

    public static BookDetailDto BookDetailToDto(this Book book)
    {
        return new BookDetailDto(book.Title, book.Price, book.Stock,
            book.Author.FullName, book.Category.Name,
            book.Publisher.Name, book.BookTags.Select(tag => tag.Tag.Name).ToList());
    }

    public static List<BookDetailDto> BookDetailToDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => b.BookDetailToDto()).ToList();
    }

    public static BookInfoDto BookInfoToDto(this Book book)
    {
        return new BookInfoDto(book.Title, book.Price, book.Stock, book.PublishYear,
            book.Author, book.Category, book.Publisher
            , book.BookTags.Select(t => t.Tag).ToList());
    }

    public static List<BookInfoDto> BookInfoToDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => b.BookInfoToDto()).ToList();
    }

    public static BookSpecsDto BookSpecsToDto(this Book book)
    {
        return new BookSpecsDto(book.Title, book.Author.FullName,
            book.Category.Name, book.Publisher.Name, book.BookTags.Select(tag => tag.Tag.Name).ToList());
    }

    public static List<BookSpecsDto> BookSpecsToDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => b.BookSpecsToDto()).ToList();
    }

    public static BookInfoByTagDto InfoByTagToDto(this Book book)
    {
        return new BookInfoByTagDto(
            book.Author.FullName,
            book.Title,
            book.Price
        );
    }

    public static List<BookInfoByTagDto> InfoByTagToDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b => b.InfoByTagToDto()).ToList();
    }

    public static BookInfoByCategoryDto InfoByCategoryToDto(this Book book)
    {
        return new BookInfoByCategoryDto(
            book.Title,
            book.Author.FullName
        );
    }

    public static List<BookInfoByCategoryDto> InfoByCategoryToDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b=> b.InfoByCategoryToDto()).ToList();
    }
    
    public static BookInfoByAuthorDto InfoByAuthorToDto(this Book book)
    {
        return new BookInfoByAuthorDto(
            book.Title,
            book.Price,
            book.Publisher.Name
        );
    }
    
    public static List<BookInfoByAuthorDto> InfoByAuthorToDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b=> b.InfoByAuthorToDto()).ToList();
    }
    
    public static BookInfoByPublisherDto InfoByPublisherToDto(this Book book)
    {
        return new BookInfoByPublisherDto(
            book.Title,
            book.Price,
            book.Publisher.Name
        );
    }
    
    public static List<BookInfoByPublisherDto> InfoByPublisherDtoList(this IEnumerable<Book> books)
    {
        return books.Select(b=> b.InfoByPublisherToDto()).ToList();
    }
    
    public static BookInfoWithPublishYearDto BookInfoWithPublishYearToDto(this Book book)
    {
        return new BookInfoWithPublishYearDto(
            book.Title,
            book.PublishYear
            );
    }

    public static List<BookInfoWithPublishYearDto> BookInfoWithPublishYearToDtoList
        (this IEnumerable<Book> books)
    {
        return books.Select(b=> b.BookInfoWithPublishYearToDto()).ToList();

    }
}