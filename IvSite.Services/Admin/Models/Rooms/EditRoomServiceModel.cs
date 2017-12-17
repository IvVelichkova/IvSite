namespace IvSite.Services.Admin.Models.Rooms
{
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Rooms;
    using IvSite.Data.Models.TypesRoom;

    public class EditRoomServiceModel:IMapFrom<Room>
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public CapacityRoom Capacity { get; set; }

        public LuxStatus LuxStatus { get; set; }

        public bool Smokers { get; set; }
    }
}
