namespace IvSite.Data.Models.Gallery
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.Users;
    using static IvSite.Data.DataConstants;

    public class Album
    {
        public int Id { get; set; }

        [MaxLength(MaxLenAlbumTitle)]
        [MinLength(MinLenAlbumTitle)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public List<Photo> Photos { get; set; } = new List<Photo>();
    }
}
