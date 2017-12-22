namespace IvSite.Services.Admin.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using IvSite.Data;
    using IvSite.Data.Models.Rooms;
    using IvSite.Data.Models.TypesRoom;
    using IvSite.Services.Admin.Models;
    using IvSite.Services.Admin.Models.Rooms;
    using Microsoft.EntityFrameworkCore;

    public class RoomService : IRoomService
    {
        private readonly IvSiteDbContext db;

        public RoomService(IvSiteDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, CapacityRoom capacity, LuxStatus luxStatus, bool smoker)
        {
            var room = new Room
            {
                Name = name,
                Capacity = capacity,
                LuxStatus = luxStatus,
                Smoker = smoker
            };

            this.db.Add(room);
            this.db.SaveChanges();
        }


        public  EditRoomServiceModel FindToEdit(int Id) => this.db.Rooms.Where(r => r.Id == Id).ProjectTo<EditRoomServiceModel>().FirstOrDefault();
       



        public void Edit(EditRoomServiceModel model)
        {

            var room = this.db.Rooms.Find(model.Id);

            room.Name = model.Name;
            room.Capacity = model.Capacity;
            room.LuxStatus = model.LuxStatus;
            room.Smoker = model.Smokers;

            this.db.Rooms.Update(room);
            this.db.SaveChanges();
        }

        public async Task<List<RoomsListingServiceModel>> AllRooms()
        {

            var res=await this.db.Rooms.ProjectTo<RoomsListingServiceModel>().ToListAsync();
            return res;

        }


    }
}

