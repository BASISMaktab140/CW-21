namespace CW._21.Services.DTOs.Books;

public record BookSpecsDto(string Title, string AuthorName, 
    string CategoryName, string PublisherName, List<string> Tags);