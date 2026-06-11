using CW21.Presentation.Entities.BookTags;
using CW21.Presentation.Entities.Tags;
using CW21.Presentation.Repositories.Books;
using CW21.Presentation.Repositories.BookTags;
using CW21.Presentation.Repositories.Generics;
using CW21.Presentation.Repositories.Tags;
using CW21.Presentation.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookTagRepository _bookTagRepository;

        public TagService(ITagRepository tagRepository, IBookRepository bookRepository ,
            IBookTagRepository bookTagRepository)
        {
            _tagRepository= tagRepository;
            _bookRepository = bookRepository;
            _bookTagRepository = bookTagRepository;
        }


        public async Task CreateTagAsync(string name )
        {
            var result = new Tag
            (
                name
            );
            await _tagRepository.AddAsync(result);
        }

        public async Task<TagInfoDto?> GetTagByIdAsync(int tagId)
        {
          var result = await _tagRepository.GetByIdAsync(tagId);
          
          if(result == null)
              throw new Exception($"Tag {tagId} not found");

          return result.GetAllTagsMapper();
        }
        public async Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize)
        {
            var tags = await _tagRepository.GetAll()
               .Include(t => t.BookTags)
               .Skip((page - 1)* pageSize).Take(pageSize).ToListAsync();
            return tags.Select(t => t.GetAllTagsMapper()).ToList();
        }
        public async Task UpdateTagAsync(int tagId, string newName)
        {
            var tag = await _tagRepository.GetByIdAsync(tagId);
            
            if(tag == null)
                throw new Exception($"Tag {tagId} not found");
            
            tag.Name = newName;
            await _tagRepository.UpdateAsync(tag);
        }

        public async Task DeleteTagAsync(int tagId)
        {
            var tag = await _tagRepository.GetByIdAsync(tagId);
            
            if(tag == null)
                throw new Exception($"Tag {tagId} not found");
            
            await _tagRepository.DeleteAsync(tagId);
        }
        
        public async Task<List<BookInfoByTag>> GetBooksByTagAsync(int tagId, int page, int pageSize)
        {
            var result = await _bookRepository.GetAll().
                Where(b => b.BookTags.Any(t => t.TagId == tagId))
                .Skip((page - 1 )*pageSize).Take(pageSize).ToListAsync();

            return result.Select(b => b.ToInfoByTag()).ToList();
        }
        
        public async Task AddTagToBookAsync(int tagId, int bookId)
        {
            var tagResult = await _tagRepository.GetByIdAsync(tagId);
            if (tagResult == null)
                throw new Exception($"Tag {tagId} not found");

            var bookResult = await _bookRepository.GetByIdAsync(bookId);
            if (bookResult == null)
                throw new Exception($"Book {bookId} not found");

            await _bookTagRepository.AddAsync(new BookTag
            {
                BookId = bookId,
                TagId = tagId
            });
        }
       
        public async Task RemoveTagFromBookAsync(int tagId, int bookId)
        {
            var tagResult = await _tagRepository.GetByIdAsync(tagId);
            if(tagResult == null)
                throw new Exception($"Tag {tagId} not found");
            
            var bookResult = await _bookRepository.GetByIdAsync(bookId);
            if(bookResult == null)
                throw new Exception($"Book {bookId} not found");
            
            await _bookTagRepository.DeleteAsync(bookResult.BookTags.First(t => t.TagId == tagId).Id);
        }
    }
}