using System.Reflection;
using CW._21.Domain.Authors;
using CW._21.Domain.Books;
using CW._21.Domain.BookTags;
using CW._21.Domain.Categories;
using CW._21.Domain.Customers;
using CW._21.Domain.OrderItems;
using CW._21.Domain.Orders;
using CW._21.Domain.OtpLogs;
using CW._21.Domain.Tags;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Data;

public class AppDbContext : IdentityUser
{

    public DbSet<Book> Books  { get; set; }
    public DbSet<Author>Authors { get; set; }
    public DbSet<Category> Categories {get; set;}
    public DbSet<BookTag> BookTags   { get; set; }
    public DbSet<Tag> Tags   { get; set; }
    public DbSet<Customer> Customers   { get; set; }
    public DbSet<Order> Orders   { get; set; }
    public DbSet<OrderItem> OrderItems   { get; set; }
    public DbSet<OtpLog> OtpLogs   { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}