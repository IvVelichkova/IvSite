namespace IvSite.Services.Admin.Models.Rooms
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Rooms;
    using IvSite.Data.Models.TypesRoom;
    using IvSite.Services.User.Models;

    public class RoomsListingServiceModel:IMapFrom<Room>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public CapacityRoom Capacity { get; set; }
        [Required]
        public LuxStatus LuxStatus { get; set; }
        [Required]
        public bool Smokers { get; set; }

        public string Note { get; set; }

        public IEnumerable<ReservationsServiceModel> Reservations { get; set; }
    }
}
