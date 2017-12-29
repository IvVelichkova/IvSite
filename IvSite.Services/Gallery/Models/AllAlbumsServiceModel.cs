using System;
using System.Collections.Generic;
using System.Text;
using IvSite.Core.Mapping;
using IvSite.Data.Models.Gallery;

namespace IvSite.Services.Gallery.Models
{
   public class AllAlbumsServiceModel:IMapFrom<Album>
    {
        public IEnumerable<CreateAlbumServiceModel> Albums { get; set; }
    }
}
