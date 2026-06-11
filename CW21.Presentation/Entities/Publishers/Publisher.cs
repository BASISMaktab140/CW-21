using System.ComponentModel.DataAnnotations;
using CW21.Presentation.Entities.Books;

namespace CW21.Presentation.Entities.Publishers;

public class Publisher : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get;  set; }
    
    [MaxLength(50)]
    public string ? City { get;  set; }
    
    [MaxLength(20)]
    public string ? PhoneNumber { get;  set; }
    
    public DateTime CreatedAt { get;  set; }

    //public int BookId { get; set; }
    public IEnumerable<Books.Book>? Books { get; set; } = new List<Book>();
}





