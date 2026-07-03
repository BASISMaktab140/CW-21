using CW._21.Domain.Books;
using CW._21.Domain.BookTags;

namespace CW._21.Domain.Tags
{
    public class Tag : BaseEntity
    {
        public Tag(string name)
        {
            Name = name;
        }

        public Tag(string name , int bookId)
        {
            Name = name;
            BookId = bookId;
        }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<BookTag> BookTags    { get; set; }
        public int BookId { get; set; }
        public List<Book> Books { get; set; } = new();


    }
}
