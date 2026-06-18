using System.ComponentModel.DataAnnotations;
using Cw._21.Abstraction;
using CW._21.Domain.Books;

namespace CW._21.Domain.Authors;

public class Author : BaseEntity
{
    private Author()
    {
    }

    public Author(string fullName, int? birthYear, string country)
    {
        FullName = fullName;
        BirthYear = birthYear;
        Country = country;
    }

    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(100, ErrorMessage = "dadash ta 100 tae ")]
    public string FullName { get; set; }
    public int? BirthYear { get; set; }
    
    [MaxLength(40,ErrorMessage =  "dadash ta 40 tae ")]
    public string Country { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
}