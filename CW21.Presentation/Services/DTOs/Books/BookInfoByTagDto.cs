using CW21.Presentation.Entities.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.DTOs
{
    public record BookInfoByTagDto(string AuthorFullName, string BookName, decimal BookPrice);
    
          
    
}
