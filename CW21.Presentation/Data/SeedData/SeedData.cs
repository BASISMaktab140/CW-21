using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.BookTags;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Entities.Publishers;

namespace CW21.Presentation.Data.SeedData;

public static class SeedData
{
    public static readonly List<Author> Authors = new()
    {
        

    new Author { Id = 1, FullName = "Jon Skeet", Country = "Romania" },
    new Author { Id = 2, FullName = "Andrew Lock", Country = "Germany" },
    new Author { Id = 3, FullName = "Martin Fowler", Country = "France" },
    new Author { Id = 4, FullName = "Robert C. Martin" , Country = "Italy" },
    new Author { Id = 5, FullName = "Julie Lerman", Country = "Poland" }


    };



    public static readonly List<Category> Categories = new()
{
    new Category { Id = 1, Name = "Programming" },
    new Category { Id = 2, Name = "Database" },
    new Category { Id = 3, Name = "Backend" },
    new Category { Id = 4, Name = "Architecture" }
};

    public static readonly List<Publisher> Publishers = new()
{
    new Publisher { Id = 1, Name = "Packt" },
    new Publisher { Id = 2, Name = "O'Reilly" },
    new Publisher { Id = 3, Name = "Manning" },
    new Publisher { Id = 4, Name = "Apress" }
};

//     public static readonly List<Tag> Tags = new()
// {
//     new Tag { Id = 1, Name = "Programming" },
//     new Tag { Id = 2, Name = "Database" },
//     new Tag { Id = 3, Name = "Backend" },
//     new Tag { Id = 4, Name = "Architecture" },
//     new Tag { Id = 5, Name = "Clean Code" }
// };

    public static readonly List<Book> Books = new()
{
    new Book
    {
        Id = 1,
        Title = "EF Core Guide",
        Price = 299.99m,
        PublishYear = 2024,
        AuthorId = 5,
        CategoryId = 2,
        PublisherId = 4,
        Stock = 50
    },
    new Book
    {
        Id = 2,
        Title = "ASP.NET Core Basics",
        Price = 199.99m,
        PublishYear = 2023,
        AuthorId = 2,
        CategoryId = 3,
        PublisherId = 2,
        Stock = 35
    },
    new Book
    {
        Id = 3,
        Title = "Clean Code",
        Price = 249.99m,
        PublishYear = 2008,
        AuthorId = 4,
        CategoryId = 1,
        PublisherId = 3,
        Stock = 40
    },
    new Book
    {
        Id = 4,
        Title = "Refactoring",
        Price = 279.99m,
        PublishYear = 2018,
        AuthorId = 3,
        CategoryId = 4,
        PublisherId = 1,
        Stock = 20
    },
    new Book
    {
        Id = 5,
        Title = "C# in Depth",
        Price = 320.00m,
        PublishYear = 2019,
        AuthorId = 1,
        CategoryId = 1,
        PublisherId = 3,
        Stock = 45
    },
    new Book
    {
        Id = 6,
        Title = "SQL Server Essentials",
        Price = 180.50m,
        PublishYear = 2022,
        AuthorId = 5,
        CategoryId = 2,
        PublisherId = 4,
        Stock = 28
    },
    new Book
    {
        Id = 7,
        Title = "Entity Framework Mastery",
        Price = 310.75m,
        PublishYear = 2021,
        AuthorId = 5,
        CategoryId = 2,
        PublisherId = 2,
        Stock = 18
    },
    new Book
    {
        Id = 8,
        Title = "Designing REST APIs",
        Price = 270.00m,
        PublishYear = 2020,
        AuthorId = 2,
        CategoryId = 3,
        PublisherId = 1,
        Stock = 33
    },
    new Book
    {
        Id = 9,
        Title = "Microservices Fundamentals",
        Price = 350.00m,
        PublishYear = 2024,
        AuthorId = 3,
        CategoryId = 4,
        PublisherId = 3,
        Stock = 22
    },
    new Book
    {
        Id = 10,
        Title = "LINQ Deep Dive",
        Price = 210.25m,
        PublishYear = 2021,
        AuthorId = 1,
        CategoryId = 1,
        PublisherId = 2,
        Stock = 26
    },
    new Book
    {
        Id = 11,
        Title = "Advanced C#",
        Price = 330.00m,
        PublishYear = 2022,
        AuthorId = 1,
        CategoryId = 1,
        PublisherId = 1,
        Stock = 31
    },
    new Book
    {
        Id = 12,
        Title = "NoSQL for Developers",
        Price = 240.99m,
        PublishYear = 2020,
        AuthorId = 3,
        CategoryId = 2,
        PublisherId = 4,
        Stock = 19
    },
    new Book
    {
        Id = 13,
        Title = "Backend Development with .NET",
        Price = 289.99m,
        PublishYear = 2023,
        AuthorId = 2,
        CategoryId = 3,
        PublisherId = 3,
        Stock = 37
    },
    new Book
    {
        Id = 14,
        Title = "Database Design Principles",
        Price = 260.00m,
        PublishYear = 2019,
        AuthorId = 5,
        CategoryId = 2,
        PublisherId = 1,
        Stock = 24
    },
    new Book
    {
        Id = 15,
        Title = "Clean Architecture",
        Price = 295.00m,
        PublishYear = 2017,
        AuthorId = 4,
        CategoryId = 4,
        PublisherId = 2,
        Stock = 29
    },
    new Book
    {
        Id = 16,
        Title = "Practical Dependency Injection",
        Price = 205.50m,
        PublishYear = 2021,
        AuthorId = 2,
        CategoryId = 3,
        PublisherId = 4,
        Stock = 17
    },
    new Book
    {
        Id = 17,
        Title = "Mastering PostgreSQL",
        Price = 275.75m,
        PublishYear = 2022,
        AuthorId = 3,
        CategoryId = 2,
        PublisherId = 2,
        Stock = 21
    },
    new Book
    {
        Id = 18,
        Title = "Software Engineering Patterns",
        Price = 315.25m,
        PublishYear = 2020,
        AuthorId = 4,
        CategoryId = 4,
        PublisherId = 3,
        Stock = 27
    },
    new Book
    {
        Id = 19,
        Title = "Building APIs with ASP.NET Core",
        Price = 285.40m,
        PublishYear = 2024,
        AuthorId = 2,
        CategoryId = 3,
        PublisherId = 1,
        Stock = 32
    },
    new Book
    {
        Id = 20,
        Title = "Data Access in .NET",
        Price = 230.00m,
        PublishYear = 2023,
        AuthorId = 5,
        CategoryId = 2,
        PublisherId = 4,
        Stock = 23
    }
};

    public static readonly List<BookTag> BookTags = new()
{
    new BookTag {Id = 1, BookId = 1, TagId = 1 },
    new BookTag {Id = 2,BookId = 1, TagId = 2 },
    new BookTag {Id = 3, BookId = 1, TagId = 3 },

    new BookTag {Id = 4, BookId = 2, TagId = 1 },
    new BookTag {Id = 5, BookId = 2, TagId = 3 },

    new BookTag {Id = 6, BookId = 3, TagId = 1 },
    new BookTag {Id = 7, BookId = 3, TagId = 5 },

    new BookTag {Id = 8, BookId = 4, TagId = 4 },
    new BookTag {Id = 9, BookId = 4, TagId = 1 },

    new BookTag {Id = 10, BookId = 5, TagId = 1 },

    new BookTag {Id = 11, BookId = 6, TagId = 2 },

    new BookTag {Id = 12, BookId = 7, TagId = 2 },
    new BookTag {Id = 13, BookId = 7, TagId = 3 },
    new BookTag {Id = 14,BookId = 7, TagId = 1 },

    new BookTag {Id = 15, BookId = 8, TagId = 3 },
    new BookTag {Id = 16, BookId = 8, TagId = 4 },

    new BookTag {Id = 17, BookId = 9, TagId = 3 },
    new BookTag {Id = 18, BookId = 9, TagId = 4 },

    new BookTag {Id = 19, BookId = 10, TagId = 1 },

    new BookTag {Id = 20, BookId = 11, TagId = 1 },
/*
    new BookTag { BookId = 12, TagId = 2 },
    new BookTag { BookId = 12, TagId = 3 },

    new BookTag { BookId = 13, TagId = 3 },
    new BookTag { BookId = 13, TagId = 1 },

    new BookTag { BookId = 14, TagId = 2 },
    new BookTag { BookId = 14, TagId = 4 },

    new BookTag { BookId = 15, TagId = 4 },
    new BookTag { BookId = 15, TagId = 5 },

    new BookTag { BookId = 16, TagId = 3 },
    new BookTag { BookId = 16, TagId = 4 },

    new BookTag { BookId = 17, TagId = 2 },

    new BookTag { BookId = 18, TagId = 4 },
    new BookTag { BookId = 18, TagId = 1 },

    new BookTag { BookId = 19, TagId = 3 },
    new BookTag { BookId = 19, TagId = 1 },

    new BookTag { BookId = 20, TagId = 2 },
    new BookTag { BookId = 20, TagId = 1 },
    new BookTag { BookId = 20, TagId = 3 }*/
};

    


}
