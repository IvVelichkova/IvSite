namespace IvSite.Services.Reserve
{
    using System;

    public interface IReserveService
    {
       
        void CreateBookingUser(int roomId, string guestId, DateTime startDate, DateTime endDate, string note);
       
    }
}
