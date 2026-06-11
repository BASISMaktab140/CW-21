using CW21.Presentation.Entities.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.DTOs
{
    public record BookInfoByTag(string AuthorFullName, string BookName, decimal BookPrice);
    
        public static class BookInfo
        {
            public static BookInfoByTag ToInfoByTag(this Book book)
            {
                return new BookInfoByTag(
                book.Author.FullName,
                book.Title,
                book.Price
                );
            }

        }

          
    
}
