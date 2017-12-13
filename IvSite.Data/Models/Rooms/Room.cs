namespace IvSite.Data.Models.Rooms
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.TypesRoom;

    using static DataConstants;

    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public CapacityRoom Capacity { get; set; }

        [Required]
        public LuxStatus LuxStatus { get; set; }

        public bool Smoker { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
