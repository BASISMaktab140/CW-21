using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Entities.Publishers;
using CW21.Presentation.Entities.Tags;

namespace CW21.Presentation.Services.DTOs;

public record BookInfoDto(string Title , decimal Price , int Stock , int PublishYear , 
    Author Author , Category Category,Publisher Publisher, List<Tag> Tags );
    
