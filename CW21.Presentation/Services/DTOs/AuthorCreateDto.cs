using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.DTOs
{
    public record AuthorCreateDto(string FullName, int? BirthYear,string Country);
}
