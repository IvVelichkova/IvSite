namespace IvSite.Web.Areas.Gallery.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static IvSite.Data.DataConstants;

    public class CreatePhotoViewModel
    {

        [MaxLength(MaxLenghtName)]
        public string Name { get; set; }
        [Required]
        [MaxLength(MaxLenUrl)]
        [MinLength(MinLenUrl)]
        public string Url { get; set; }

        public IEnumerable<CreateCommentViewModel> Commens { get; set; }
    }
}
