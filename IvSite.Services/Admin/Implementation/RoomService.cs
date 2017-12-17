namespace IvSite.Services.Admin.Implementation
{
    using System;
    using System.Collections.Generic;
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

        public void All()
        {
            throw new NotImplementedException();
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

        public void Edit(int id, string name, CapacityRoom capacity, LuxStatus luxStatus, bool smoker)
        {

            var room = this.db.Rooms.Find(id);

            room.Name = name;
            room.Capacity = capacity;
            room.LuxStatus = luxStatus;
            room.Smoker = smoker;

            this.db.SaveChanges();
        }

        public async Task<IEnumerable<RoomsListingServiceModel>> AllRooms()
        {
            return await this.db.Users.ProjectTo<RoomsListingServiceModel>().ToListAsync();
        }

        
    }
}

