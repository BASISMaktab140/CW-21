using System.ComponentModel.DataAnnotations;
using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Entities.BookTags;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Entities.Publishers;
using CW21.Presentation.Entities.Tags;

namespace CW21.Presentation.Entities.Books;

public class Book : BaseEntity
{
    public Book()
    {

    }

    public Book(string title, decimal price, int publishYear, int authorId, int categoryId, int stock, int publisherId)
    {
        Title = title;
        Price = price;
        PublishYear = publishYear;
        AuthorId = authorId;
        CategoryId = categoryId;
        Stock = stock;
        PublisherId = publisherId;
        //BookTags = bookTags;
    }
    public Book(string title, decimal price, int publishYear, int authorId, Author author, int categoryId, Category category, int stock, int publisherId, Publisher publisher, List<BookTag> bookTags)
    {
        Title = title;
        Price = price;
        PublishYear = publishYear;
        AuthorId = authorId;
        Author = author;
        CategoryId = categoryId;
        Category = category;
        Stock = stock;
        PublisherId = publisherId;
        Publisher = publisher;
        //BookTags = bookTags;
    }

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100)]
    public string Title { get; set; }
   [Range(typeof(decimal), "0.01", "9999999999999999.99")]
    public decimal Price { get; set; }
    public int PublishYear { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    
    public List<BookTag> BookTags { get; set; }
}