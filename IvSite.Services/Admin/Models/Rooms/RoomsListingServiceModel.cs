using System;
using System.Collections.Generic;
using System.Text;
using IvSite.Core.Mapping;
using IvSite.Data.Models.Rooms;
using IvSite.Data.Models.TypesRoom;

namespace IvSite.Services.Admin.Models.Rooms
{
  public  class RoomsListingServiceModel:IMapFrom<Room>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Capacity { get; set; }

        public string LuxStatus { get; set; }

        public bool Smokers { get; set; }
    }
}
