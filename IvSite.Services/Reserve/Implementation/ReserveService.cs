namespace IvSite.Services.Reserve.Implementation
{
    using System;
    using IvSite.Data;
    using IvSite.Data.Models.Rooms;
    using IvSite.Services.Admin;
    using IvSite.Services.User;

    public class ReserveService : IReserveService
    {
        private readonly IvSiteDbContext db;
        private readonly IUserService users;
        private readonly IRoomService rooms;

        public ReserveService(IvSiteDbContext db,
            IUserService users,
            IRoomService rooms)
        {
            this.db = db;
            this.users = users;
            this.rooms = rooms;
        }


        public void CreateBookingUser(int roomId, string guestId, DateTime startDate, DateTime endDate, string note)
        {
            var reserve = new Reservation
            {
                RoomId = roomId,
                GuestId = guestId,
                StartDate = startDate,
                EndDate = endDate,
                Note = note
            };


            this.db.Reserve.Add(reserve);
            this.db.SaveChanges();
        }


    }
}
