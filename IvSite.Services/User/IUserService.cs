namespace IvSite.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Services.Admin.Models.Rooms;

    public interface IUserService
    {

        Task<List<RoomsListingServiceModel>> AllFreeRooms(DateTime startDate, DateTime endDate);
    }
}
