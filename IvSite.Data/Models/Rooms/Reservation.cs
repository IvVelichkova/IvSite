namespace IvSite.Data.Models.Rooms
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.Users;
    using static DataConstants;
    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public string GuestId { get; set; }

        public User Guest { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(MaxLenNote)]
        public string Note { get; set; }

    }
}
