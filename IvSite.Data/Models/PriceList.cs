using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IvSite.Data.Models.Users;

namespace IvSite.Data.Models
{
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
