using System.Collections.Generic;
using IvSite.Services.User.Models;

namespace IvSite.Web.Areas.User.Models
{
    public class AllRoomsFormForBookingModel
    {
       
        
            public IEnumerable<RoomListingUserListingModel> Rooms { get; set; }
        
    }
}
