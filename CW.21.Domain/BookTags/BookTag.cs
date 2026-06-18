using Cw._21.Abstraction;
using CW._21.Domain.Books;
using CW._21.Domain.Tags;

namespace CW._21.Domain.BookTags
{
    
    public class BookTag : BaseEntity
    {
        public BookTag()
        {
            
        }

        public BookTag(int bookId, int tagId)
        {
            BookId = bookId;
            TagId = tagId;
        }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
