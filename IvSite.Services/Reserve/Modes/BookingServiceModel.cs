namespace IvSite.Services.Reserve.Modes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static IvSite.Data.DataConstants;
    public class BookingServiceModel
    {

        public int RoomId { get; set; }

        public string GuestId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(MaxLenNote)]
        public string Note { get; set; }
    }
}
