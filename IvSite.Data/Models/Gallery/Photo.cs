namespace IvSite.Data.Models.Gallery
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static IvSite.Data.DataConstants;

    public class Photo
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
        
        [MaxLength(MaxLenghtName)]
        public string Name { get; set; }
        [Required]
        [MaxLength(MaxLenUrl)]
        [MinLength(MinLenUrl)]
        public string Url { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
