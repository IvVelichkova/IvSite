namespace IvSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.Users;

    public  class PriceList
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public string AdminId { get; set; }

        public User Admin { get; set; }

    }
}
