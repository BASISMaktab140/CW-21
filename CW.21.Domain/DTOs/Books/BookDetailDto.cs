namespace CW._21.Services.DTOs.Books;


public record BookDetailDto(string Title,decimal Price, int Stock, 
    string AuthorName,string CategoryName,
    string PublisherName, List<string> Tags);



