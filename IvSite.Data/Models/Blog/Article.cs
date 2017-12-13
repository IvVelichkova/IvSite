namespace IvSite.Data.Models.Blog
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.Users;

    using static DataConstants;
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLenTitle)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
