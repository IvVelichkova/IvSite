namespace IvSite.Services.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Services.Admin.Models;

    public interface IAdminUsersService
    {
        Task<IEnumerable<AdminUsersListingServiceModel>> All();
    }
}
