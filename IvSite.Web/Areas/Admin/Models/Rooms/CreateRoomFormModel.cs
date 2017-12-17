namespace IvSite.Web.Areas.Admin.Models.Rooms
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateRoomFormModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<SelectListItem>  Capacity { get; set; }
        [Required]
        public IEnumerable<SelectListItem> LuxStatus { get; set; }
        [Required]
        public bool Smokers { get; set; }
    }
}
