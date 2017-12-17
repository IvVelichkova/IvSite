using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvSite.Services.Admin.Models.Rooms;

namespace IvSite.Web.Areas.Admin.Models.Rooms
{
    public class AllRoomsViewModel
    {
        public IEnumerable<RoomsListingServiceModel> Rooms { get; set; }
    }
}
