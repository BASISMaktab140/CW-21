// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Serialization;
using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Entities.Publishers;
using CW21.Presentation.Repositories;
using CW21.Presentation.Repositories.Books;
using CW21.Presentation.Repositories.Categories;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Repositories.Publishers;
using CW21.Presentation.Services.Books;
using CW21.Presentation.Services.Categories;
using CW21.Presentation.Services.Publishers;

var context = new AppDbContext();

Console.WriteLine();
var bookRepo = new BookRepository(context);
var bookService = new BookService(bookRepo);

var bookDetails = await bookService.GetAllBooksWithDetailsAsync();

/*Console.WriteLine(JsonSerializer.Serialize(bookDetails, 
    new JsonSerializerOptions
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    }));*/

var publisherRepo = new PublisherRepository(context);
var publisherService = new PublisherService(publisherRepo);

var publisherDetails = await  publisherService.GetAllPublishersWithDetails();

/*
Console.WriteLine(JsonSerializer.Serialize(publisherDetails, new JsonSerializerOptions
{
    WriteIndented = true,
    ReferenceHandler = ReferenceHandler.IgnoreCycles
}));
*/

var categoryRepo = new CategoryRepository(context);
var categoryService = new CategoryService(categoryRepo);


var categoryDetails = await  categoryService.GetAllCategoryBooks();
/*
Console.WriteLine(JsonSerializer.Serialize(categoryDetails, new JsonSerializerOptions
{
    WriteIndented = true,
    ReferenceHandler = ReferenceHandler.IgnoreCycles
}));
*/


var booksWithCriteria = await  bookService.GetBooksMeetCriteria(0);

var averagePrice = bookRepo.GetAll().Average(b => b.Price);
/*Console.WriteLine($"Average:{averagePrice} ");

Console.WriteLine("All Books With Criteria:");
Console.WriteLine(JsonSerializer.Serialize(booksWithCriteria, 
    new JsonSerializerOptions
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    }));*/
    
var publisherBookCount = await publisherService.GetAllPublishersWithMinimumBooks(2);

/*Console.WriteLine(JsonSerializer.Serialize(publisherBookCount, 
        new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        }));*/
        
var publisherBookDetails = await publisherService.GetAllPublisherBooksDetails();
        
        /*Console.WriteLine(JsonSerializer.Serialize(publisherBookDetails, 
            new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            }));*/
            
            var publisherMostExpensiveBooks = await publisherService.GetPublisherMostExpensiveBookPrices();
            Console.WriteLine(JsonSerializer.Serialize(publisherMostExpensiveBooks, 
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                })); 