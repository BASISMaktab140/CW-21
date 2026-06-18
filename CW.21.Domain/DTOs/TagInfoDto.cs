using CW._21.Domain.Tags;

namespace CW._21.Services.DTOs
{
    public record TagInfoDto(int TagId, string TagName, int BookCount);
    public static class TagMapper
    {
        public static TagInfoDto GetAllTagsMapper(this Tag tag)
        {
            return new TagInfoDto(

                tag.Id,
                tag.Name,
                tag.BookTags?.Count ?? 0);

        }
    }
}
