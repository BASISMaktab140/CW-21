using CW._21.Domain.Books;
using CW._21.Domain.BookTags;
using CW._21.Domain.DTOs;
using CW._21.Domain.DTOs.Tags;
using CW._21.Domain.Tags;

namespace CW._21.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookTagRepository _bookTagRepository;

        public TagService(ITagRepository tagRepository, IBookRepository bookRepository,
            IBookTagRepository bookTagRepository)
        {
            _tagRepository = tagRepository;
            _bookRepository = bookRepository;
            _bookTagRepository = bookTagRepository;
        }


        public async Task CreateTagAsync(string name)
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

            if (result == null)
                throw new Exception($"Tag {tagId} not found");

            return result.GetAllTagsMapper();
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
            if (tagResult == null)
                throw new Exception($"Tag {tagId} not found");

            var bookResult = await _bookRepository.GetByIdAsync(bookId);
            if (bookResult == null)
                throw new Exception($"Book {bookId} not found");

            await _bookTagRepository.DeleteAsync(bookResult.BookTags.First(t => t.TagId == tagId).Id);
        }

        public async Task<List<TagInfoDto>> GetAllTagsAsync(int page, int pageSize)
        {
            return await _tagRepository.GetAllTagsAsync(page, pageSize);
        }
        
    }
}