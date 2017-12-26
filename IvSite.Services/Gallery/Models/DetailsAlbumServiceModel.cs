using System.Collections.Generic;
using IvSite.Core.Mapping;
using IvSite.Data.Models.Gallery;

namespace IvSite.Services.Gallery.Models
{
    public class DetailsAlbumServiceModel:IMapFrom<Album>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<CreatePhotoServiceModel> Photos { get; set; } = new List<CreatePhotoServiceModel>();
    }
}
