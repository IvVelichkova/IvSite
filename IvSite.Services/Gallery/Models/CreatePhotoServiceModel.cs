namespace IvSite.Services.Gallery.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Gallery;

    using static IvSite.Data.DataConstants;

    public class CreatePhotoServiceModel:IMapFrom<Photo>
    {
        public int Id { get; set;  }

        [MaxLength(MaxLenghtName)]
        public string Name { get; set; }
        [Required]
        [MaxLength(MaxLenUrl)]
        [MinLength(MinLenUrl)]
        
        public string Url { get; set; }

        public int AlbumId { get; set; }

        public IEnumerable<CreateCommentServiceModel> Commens { get; set; }
    }
}
