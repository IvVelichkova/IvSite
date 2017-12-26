namespace IvSite.Web.Areas.Blog.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class CreateArticleFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxLenTitle, MinimumLength = MinLenTitle)]
        public string Title { get; set; }

        [Required]
        [StringLength(MaxContentLen, MinimumLength = MinContentLen)]
        public string Content { get; set; }

    }
}
