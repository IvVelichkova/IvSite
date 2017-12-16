namespace IvSite.Web.Areas.Admin.Models.Users
{
    using System.Collections.Generic;
    using IvSite.Services.Admin.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AdminUsersViewModel
    {
        public IEnumerable<AdminUsersListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

    }
}
