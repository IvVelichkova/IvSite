namespace IvSite.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using IvSite.Data.Models.Users;
    using IvSite.Services.Admin;
    using IvSite.Services.Admin.Models;
    using IvSite.Services.Blog;
    using IvSite.Services.HtmlSanitaizer;
    using IvSite.Services.PricessList;
    using IvSite.Services.PricessList.Models;
    using IvSite.Services.Reserve;
    using IvSite.Services.User;
    using IvSite.Web.Areas.Admin.Models.Users;
    using IvSite.Web.Areas.Blog.Models;
    using IvSite.Web.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using static IvSite.Web.WebConstants;


    public class HomeController : BaseController
    {
        private readonly IAdminUsersService users;
        //private readonly IUserService user;
        //private readonly IRoomService rooms;
        //private readonly IReserveService reserve;
        //private readonly IBlogArticleService blogArticle;
        private readonly IHtmlSanitizerService html;
        private readonly IPriceListService price;

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public HomeController(IAdminUsersService users,
                 RoleManager<IdentityRole> roleManager,
                 UserManager<User> userManager,
                 IHtmlSanitizerService html,
                 IPriceListService price)
        {

            this.html = html;
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.price = price;
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

        public async Task<IActionResult> Index()
        {
            var list = await this.price.AllPriceList();
            return View(list);

        }

        public async Task<IActionResult> CreatePriceList()
        {
            var admins = await this.userManager
                .GetUsersInRoleAsync(AdminRole);
            return View(new AdminCreatePriceListingServicemodel());
        }
        [HttpPost]
        public IActionResult CreatePriceList(AdminCreatePriceListingServicemodel priceList)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddSuccessMessage($"ModelState was not valid!");
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            priceList.Content = this.html.Sanitize(priceList.Content);

            var userId = userManager.GetUserId(User);
            this.price.CreatePriceListAsync(priceList.Title, priceList.Content, userId);
            TempData.AddSuccessMessage($"You successfully Create New Price List {priceList.Title}");
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

     

        public IActionResult DeletePriceList(int id)
        {

            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            var model = this.price.FindToDelete(id);
            return View(model);

        }
        [HttpPost]
        public IActionResult DeletePriceList(int id, AdminCreatePriceListingServicemodel price)
        {
            if (!ModelState.IsValid)
            {
                return View(price);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            this.price.DeletePriceList(
                id,
                price.Title,
                price.Content
               );

            TempData.AddSuccessMessage($"You successfully Delete Price List {price.Title}");
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        public IActionResult Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(price);
            }
            return this.View(this.price.ById(id));
        }
    }
}
