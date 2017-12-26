using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IvSite.Core.Mapping;
using IvSite.Data.Models.Gallery;
using static IvSite.Data.DataConstants;
using IvSite.Data.Models.Users;

namespace IvSite.Services.Gallery.Models
{
   public  class CreateAlbumServiceModel:IMapFrom<Album>
    {
        public int Id { get; set; }
        [MaxLength(MaxLenAlbumTitle)]
        [MinLength(MinLenAlbumTitle)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public string PhotoName { get; set; }
        public string PhotoUrl { get; set; }

    }
}
