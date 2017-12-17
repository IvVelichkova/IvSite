using System;
using System.Collections.Generic;
using System.Text;

namespace IvSite.Services.Admin.Models.Rooms
{
   public class AllRoomsListingServiceModel
    {
        public IEnumerable<RoomsListingServiceModel> Rooms { get; set; }
    }
}
