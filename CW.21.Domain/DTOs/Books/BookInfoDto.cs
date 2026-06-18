using CW._21.Domain.Authors;
using CW._21.Domain.Categories;
using CW._21.Domain.Publishers;
using CW._21.Domain.Tags;

namespace CW._21.Domain.DTOs.Books;

public record BookInfoDto(string Title , decimal Price , int Stock , int PublishYear , 
    Author Author , Category Category,Publisher Publisher, List<Tag> Tags );
    
