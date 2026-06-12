namespace CW21.Presentation.Services.DTOs;

public record BookSpecsDto(string Title, string AuthorName, 
    string CategoryName, string PublisherName, List<string> Tags);