namespace IvSite.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.Blog;
    using IvSite.Data.Models.Gallery;
    using IvSite.Data.Models.Rooms;
    using Microsoft.AspNetCore.Identity;

    using static DataConstants;
    public class User : IdentityUser
    {
        [Required]
        [MinLength(MinLenghtName)]
        [MaxLength(MaxLenghtName)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(MinLenghtName)]
        [MaxLength(MaxLenghtName)]
        public string LastName { get; set; }
        [Required]
        [MinLength(MinLenPhone)]
        [MaxLength(MaxLenPhone)]
        public string Phone { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<PriceList> PriceList { get; set; } = new List<PriceList>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
