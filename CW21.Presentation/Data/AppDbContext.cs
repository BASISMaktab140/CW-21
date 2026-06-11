using System.Reflection;
using CW21.Presentation.Entities.Authors;
using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.BookTags;
using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Entities.Tags;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Data;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books  { get; set; }
    public DbSet<Author>Authors { get; set; }
    public DbSet<Category> Categories {get; set;}
    public DbSet<BookTag> BookTags   { get; set; }
    public DbSet<Tag> Tags   { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookStoreDb;TrustServerCertificate=True;Integrated Security=True;");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}