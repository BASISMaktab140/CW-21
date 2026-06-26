
using CW._21.Domain.Authors;
using CW._21.Domain.Books;
using CW._21.Domain.BookTags;
using CW._21.Domain.Categories;
using CW._21.Domain.Customers;
using CW._21.Domain.Orders;
using CW._21.Domain.OtpLogs;
using CW._21.Domain.Publishers;
using CW._21.Domain.Tags;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Authors;
using CW._21.Infrastructures.Repositories.Books;
using CW._21.Infrastructures.Repositories.BookTags;
using CW._21.Infrastructures.Repositories.Categories;
using CW._21.Infrastructures.Repositories.Customers;
using CW._21.Infrastructures.Repositories.Orders;
using CW._21.Infrastructures.Repositories.OtpLogs;
using CW._21.Infrastructures.Repositories.Publishers;
using CW._21.Infrastructures.Repositories.Tags;
using CW._21.Services.Authors;
using CW._21.Services.Books;
using CW._21.Services.Categories;
using CW._21.Services.Customers;
using CW._21.Services.Orders;
using CW._21.Services.Publishers;
using CW._21.Services.Redis;
using CW._21.Services.Tags;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "BookStore:";
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


//builder.Services.AddOpenApi();





builder.Services.AddScoped<IAuthorRepository , AuthorRepository>();
builder.Services.AddScoped<IBookRepository , BookRepository>();
builder.Services.AddScoped<IBookTagRepository , BookTagRepository>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<IPublisherRepository , PublisherRepository>();
builder.Services.AddScoped<ITagRepository , TagRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOtpLogRepository, OtpLogRepository>();
builder.Services.AddScoped<IBookService , BookService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IPublisherService , PublisherService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRedisService, RedisService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //  app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();