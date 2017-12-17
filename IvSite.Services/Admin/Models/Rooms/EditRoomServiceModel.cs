namespace IvSite.Services.Admin.Models.Rooms
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Rooms;
    using IvSite.Data.Models.TypesRoom;

    public class EditRoomServiceModel:IMapFrom<Room>
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
    }
}
