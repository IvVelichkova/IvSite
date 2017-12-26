namespace IvSite.Services.Admin.Models.Rooms
{
    using System.Collections.Generic;

    public class AllRoomsListingServiceModel
    {
        public IEnumerable<RoomsListingServiceModel> Rooms { get; set; }
    }
}
