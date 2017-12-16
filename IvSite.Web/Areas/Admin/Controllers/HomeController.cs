namespace IvSite.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using IvSite.Data.Models.Users;
    using IvSite.Services.Admin;
    using IvSite.Web.Areas.Admin.Models.Users;
    using IvSite.Web.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : BaseController
    {
        private readonly IAdminUsersService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public HomeController(IAdminUsersService users,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            //var result = this.users.All();
            //return View(result);
            return View();
        }
        public async Task<IActionResult> AllUsers()
        {
            var users = await this.users.All();
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();
            return View(new AdminUsersViewModel
            {
                Users = users,
                Roles = roles
            });

        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var role = model.Role;
            var roleExists = await this.roleManager.RoleExistsAsync(role);
            var userExists = user != null;
            var userIsInRole = await this.userManager.IsInRoleAsync(user, role);

            
            if (!roleExists || !userExists)
            {
                ModelState.TryAddModelError(string.Empty, "Invalid Identity details");
            }


            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllUsers));
            }
            await this.userManager.AddToRoleAsync(user, model.Role);
            
            TempData.AddSuccessMessage($"User {user.UserName} successfully added  to {model.Role} role.");
            return RedirectToAction(nameof(AllUsers));
        }

        public IActionResult AllRooms()
        {
            return View();
        }
        public IActionResult AddRoom()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
