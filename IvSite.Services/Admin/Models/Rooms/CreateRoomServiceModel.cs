namespace IvSite.Services.Admin.Models.Rooms
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Data.Models.TypesRoom;

    public class CreateRoomServiceModel
    {
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
