namespace IvSite.Web.Areas.Users.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Rooms;

    using static IvSite.Data.DataConstants;

    public class BookingForm : IMapFrom<Reservation>
    {
        public int RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(MaxLenNote)]
        public string Note { get; set; }
       
    }
}
