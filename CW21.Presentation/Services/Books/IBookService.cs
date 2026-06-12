using CW21.Presentation.Entities.Books;
using CW21.Presentation.Services.DTOs;

namespace CW21.Presentation.Services.Books;

public interface IBookService
{

    /// <summary>
    /// همه ی کتاب ها با جزییات اسم و قیمت و ...
    /// </summary>
    /// <returns></returns>
    Task<List<BookDetailDto>> GetAllBooksWithDetailsAsync();

    /// <summary>
    ///  کتاب با  id مشخص
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BookInfoDto> GetBookByIdAsync(int id);
    
    /// <summary>
    /// کتاب های موجود
    /// </summary>
    /// <returns></returns>
    Task<List<BookInfoDto>> GetAvailableBooksAsync();
    
    /// <summary>
    ///  جست و جو کتاب با عنوان
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    Task<List<BookInfoDto>> GetBookByTitleAsync(string title);
    
    /// <summary>
    /// اضافه کردن کتاب
    /// </summary>
    /// <param name="bookInfo"></param>
    /// <returns></returns>
    Task<bool> AddBookAsync(BookInfoDto bookInfo);
    
    /// <summary>
    /// کتاب های با میانگین قیمت و حداقل موجودی ورودی
    /// </summary>
    /// <param name="minimumQuantity"></param>
    /// <returns></returns>
    Task<List<Book>?> GetBooksWithMinimumPriceAsync(int minimumQuantity);
    
    /// <summary>
    /// همه کتاب ها همراه با نویسنده، دستهبندی، ناشر و تگ ها
    /// </summary>
    /// <returns></returns>
    Task<List<BookSpecsDto>> GetBookSpecsAsync();
    
    /// <summary>
    /// تمام کتاب های یک برچسب
    /// </summary>
    /// <param name="tagName"></param>
    /// <returns></returns>
    Task<List<BookInfoByTagDto>> GetBooksByTagAsync(string tagName);
    
    /// <summary>
    /// تمام کتاب های یک دسته بندی
    /// </summary>
    /// <param name="categoryName"></param>
    /// <returns></returns>
    Task<List<BookInfoByCategoryDto>> GetBooksByCategoryAsync(string categoryName);
    
    /// <summary>
    /// نمایش کتاب های یک نویسنده
    /// </summary>
    /// <param name="authorName"></param>
    /// <returns></returns>
    Task<List<BookInfoByAuthorDto>> GetBooksByAuthorAsync(string authorName);
    
    /// <summary>
    /// نمایش کتاب های یک ناشر
    /// </summary>
    /// <param name="publisherName"></param>
    /// <returns></returns>
    Task<List<BookInfoByPublisherDto>> GetBooksByPublisherAsync(string publisherName);
    
    /// <summary>
    /// فیلتر کتاب براساس بازه قیمت
    /// </summary>
    /// <param name="minPrice"></param>
    /// <param name="maxPrice"></param>
    /// <returns></returns>
    Task<List<BookInfoByPublisherDto>> GetBooksByPriceRange(decimal minPrice, decimal maxPrice);
    
    /// <summary>
    /// فیلتر کتاب ها براساس سال انتشار
    /// </summary>
    /// <param name="publishYear"></param>
    /// <returns></returns>
    Task<List<BookInfoWithPublishYearDto>> GetBooksByPublishYearAsync(int publishYear);
    
    Task<bool> UpdateBookAsync(int id, BookUpdateDto bookUpdateDto);
    Task<bool> DeleteBookAsync(int id);
}