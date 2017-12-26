namespace IvSite.Services.Gallery.Models
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Gallery;
    using static IvSite.Data.DataConstants;

    public class CreateCommentServiceModel:IMapFrom<Comment>
    {
        public string UserId { get; set; }

        public int? PhotoId { get; set; }

        [MaxLength(MaxLenComment)]
        [MinLength(MinLenComment)]
        public string Content { get; set; }
    }
}
