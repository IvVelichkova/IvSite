﻿namespace IvSite.Services.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Data.Models.TypesRoom;
    using IvSite.Services.Admin.Models.Rooms;

    public interface IRoomService
    {
        void Create(string name, CapacityRoom capacity, LuxStatus luxStatus, bool smoker);
        EditRoomServiceModel FindToEdit(int Id);
        Task<List<RoomsListingServiceModel>> AllRooms();
        void Edit(EditRoomServiceModel model);
        void DeleteRoomService(EditRoomServiceModel model);
    }
}
