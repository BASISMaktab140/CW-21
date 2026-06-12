using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Tags;

namespace CW21.Presentation.Services.DTOs;


public record BookDetailDto(string Title,decimal Price, int Stock, 
    string AuthorName,string CategoryName,
    string PublisherName, List<string> Tags);



