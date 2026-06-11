using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.DTOs
{
    public record AuthorInfoDto(int Id,string FullName, int? BirthYear, string Country);
}
