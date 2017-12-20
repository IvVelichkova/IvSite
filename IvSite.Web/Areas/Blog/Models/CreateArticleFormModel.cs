namespace IvSite.Web.Areas.Blog.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class CreateArticleFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLenTitle)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
