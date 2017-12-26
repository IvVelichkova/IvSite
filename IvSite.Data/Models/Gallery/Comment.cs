namespace IvSite.Data.Models.Gallery
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.Users;

    using static IvSite.Data.DataConstants;

    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int PhotoId { get; set; }

        public Photo Photo { get; set; }
        [MaxLength(MaxLenComment)]
        [MinLength(MinLenComment)]
        public string Content { get; set; }
    }
}
