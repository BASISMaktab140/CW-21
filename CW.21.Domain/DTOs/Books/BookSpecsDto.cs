namespace CW._21.Domain.DTOs.Books;

public record BookSpecsDto(string Title, string AuthorName, 
    string CategoryName, string PublisherName, List<string> Tags);