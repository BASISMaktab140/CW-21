using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Entities.BookTags
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
