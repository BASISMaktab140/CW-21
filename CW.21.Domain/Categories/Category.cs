using System.ComponentModel.DataAnnotations;
using CW._21.Domain.Books;

namespace CW._21.Domain.Categories;

public class Category : BaseEntity
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(50,ErrorMessage = "dadash ta 50 tae ")]
    public string Name { get; set; }
    public string ? Description { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
}