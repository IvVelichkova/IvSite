namespace IvSite.Web.Areas.Admin.Models.Rooms
{
    using System.Collections.Generic;
    using IvSite.Services.Admin.Models.Rooms;

    public class AllRoomsViewModel
    {
        public IEnumerable<RoomsListingServiceModel> Rooms { get; set; }
    }
}
