namespace IvSite.Services.Admin.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using IvSite.Data;
    using IvSite.Services.Admin.Models;
    using Microsoft.EntityFrameworkCore;

    public class AdminUsersService : IAdminUsersService
    {
        private readonly IvSiteDbContext db;

        public AdminUsersService(IvSiteDbContext db)
        {
           this.db = db;
        }

        public async Task<IEnumerable<AdminUsersListingServiceModel>> All()
        {
            return await this.db.Users.ProjectTo<AdminUsersListingServiceModel>().ToListAsync();
        }
    }
}
