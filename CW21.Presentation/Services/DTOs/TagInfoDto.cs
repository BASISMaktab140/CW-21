using CW21.Presentation.Entities.Categories;
using CW21.Presentation.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Services.DTOs
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
