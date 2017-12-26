namespace IvSite.Web.Areas.Gallery.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Gallery;
    using static IvSite.Data.DataConstants;

    public class CreateAlbumViewModel:IMapFrom<Album>
    {
        public int Id { get; set; }
        [MaxLength(MaxLenAlbumTitle)]
        [MinLength(MinLenAlbumTitle)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public IEnumerable<CreatePhotoViewModel> Photos { get; set; } 

    }
}
