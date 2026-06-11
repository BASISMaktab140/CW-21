using System.ComponentModel.DataAnnotations;
using CW21.Presentation.Entities.Books;

namespace CW21.Presentation.Entities.Authors;

public class Author : BaseEntity
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(100, ErrorMessage = "dadash ta 100 tae ")]
    public string FullName { get; set; }
    public int? BirthYear { get; set; }
    
    [MaxLength(40,ErrorMessage =  "dadash ta 40 tae ")]
    public string Country { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
}