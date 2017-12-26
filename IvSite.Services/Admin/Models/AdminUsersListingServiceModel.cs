namespace IvSite.Services.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Users;
    using static Data.DataConstants;

    public class AdminUsersListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [MinLength(MinLenghtName)]
        [MaxLength(MaxLenghtName)]
        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
