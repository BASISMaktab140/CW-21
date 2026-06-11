using CW21.Presentation.Data;
using CW21.Presentation.Repositories.Authurs;
using CW21.Presentation.Repositories.Books;
using CW21.Presentation.Repositories.BookTags;
using CW21.Presentation.Repositories.Categories;
using CW21.Presentation.Repositories.Publishers;
using CW21.Presentation.Repositories.Tags;
using CW21.Presentation.Services.Books;
using CW21.Presentation.Services.Categories;
using CW21.Presentation.Services.Publishers;
using CW21.Presentation.Services.Tags;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
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
builder.Services.AddScoped<IBookService , BookService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IPublisherService , PublisherService>();
builder.Services.AddScoped<ITagService , TagService>();
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