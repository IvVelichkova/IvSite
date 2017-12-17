using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IvSite.Data.Models.TypesRoom;
using IvSite.Services.Admin.Models.Rooms;

namespace IvSite.Services
{
    public interface IRoomService
    {
        void Create(string name, CapacityRoom capacity, LuxStatus luxStatus, bool smoker);


        void Edit(int id, string name, CapacityRoom capacity, LuxStatus luxStatus, bool smoker);

        Task<IEnumerable<RoomsListingServiceModel>> AllRooms();
    }
}
