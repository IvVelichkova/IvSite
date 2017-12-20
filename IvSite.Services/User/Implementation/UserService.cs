namespace IvSite.Services.User.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Data;
    using IvSite.Services.Admin.Models.Rooms;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System;
    using IvSite.Services.User.Models;



    public class UserService : IUserService
    {
        private readonly IvSiteDbContext db;

        public UserService(IvSiteDbContext db)
        {
            this.db = db;
        }



        public async Task<List<RoomsListingServiceModel>> AllFreeRooms(DateTime startDate, DateTime endDate)
        {
            var res = await this.db
                .Rooms.Where
                (h => h.Reservations
                .All
                (d => (d.StartDate >= startDate && d.EndDate >= startDate && d.StartDate >= endDate && d.EndDate >= endDate)
                || (d.StartDate <= startDate && d.EndDate <= startDate && d.StartDate <= endDate && endDate >= d.EndDate))).Select(r => new RoomsListingServiceModel
                {
                    Capacity = r.Capacity,
                    Id = r.Id,
                    Name = r.Name,
                    LuxStatus = r.LuxStatus,
                    Smokers = r.Smoker

                }).ToListAsync();

            return res;

        }






    }
}
