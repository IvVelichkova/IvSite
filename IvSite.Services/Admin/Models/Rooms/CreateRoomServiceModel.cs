using System;
using System.Collections.Generic;
using System.Text;
using IvSite.Data.Models.TypesRoom;

namespace IvSite.Services.Admin.Models.Rooms
{
    public class CreateRoomServiceModel
    {
        public string Name { get; set; }

        public CapacityRoom Capacity { get; set; }

        public LuxStatus LuxStatus { get; set; }

        public bool Smokers { get; set; }
    }
}
