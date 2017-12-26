using System;
using System.Collections.Generic;
using System.Text;

namespace IvSite.Services.Gallery.Models
{
   public class AllAlbumsServiceModel
    {
        public IEnumerable<CreateAlbumServiceModel> Albums { get; set; }
    }
}
