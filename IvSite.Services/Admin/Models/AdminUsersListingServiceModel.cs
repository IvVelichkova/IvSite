namespace IvSite.Services.Admin.Models
{
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Users;

    public class AdminUsersListingServiceModel:IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
