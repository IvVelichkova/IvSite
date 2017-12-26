namespace IvSite.Web.Areas.Gallery.Models
{
    using System.ComponentModel.DataAnnotations;

    using static IvSite.Data.DataConstants;
    public class CreateCommentViewModel
    {

        public string UserId { get; set; }

        public int? PhotoId { get; set; }

        [MaxLength(MaxLenComment)]
        [MinLength(MinLenComment)]
        public string Content { get; set; }
    }
}
