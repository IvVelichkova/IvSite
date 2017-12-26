namespace IvSite.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using IvSite.Data.Models.Users;
    using IvSite.Services.Admin;
    using IvSite.Services.HtmlSanitaizer;
    using IvSite.Services.PricessList;
    using IvSite.Services.PricessList.Models;
    using IvSite.Web.Areas.Admin.Models.Users;
    using IvSite.Web.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using static IvSite.Web.WebConstants;
    using static IvSite.Web.WebHelper;


    public class HomeController : BaseController
    {
        private readonly IAdminUsersService users;
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
                ModelState.TryAddModelError(string.Empty, InvalidIdentityDetails);
            }


            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return RedirectToAction(nameof(AllUsers));
            }
            await this.userManager.AddToRoleAsync(user, model.Role);
            var userName = user.FirstName;

            TempData.AddSuccessMessage(UserAddedSuccessFullToRole(userName, model.Role));
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
                TempData.AddErrorMessage(ErrorModelState());
                return RedirectToAction(IndexAction, HomeControllerConst, new { area = AdminArea });
            }

            priceList.Content = this.html.Sanitize(priceList.Content);

            var userId = userManager.GetUserId(User);
            this.price
                .CreatePriceListAsync(priceList.Title, priceList.Content, userId);
            TempData
                .AddSuccessMessage(SuccessfullCreatePriceList(priceList.Title));
            return RedirectToAction(IndexAction, HomeControllerConst, new { area = AdminArea });
        }



        public IActionResult DeletePriceList(int id)
        {

            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            var model = this.price.FindToDelete(id);
            return View(model);

        }
        [HttpPost]
        public IActionResult DeletePriceList(int id, AdminCreatePriceListingServicemodel price)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return View(price);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            this.price.DeletePriceListService(
                id,
                price.Title,
                price.Content
               );

            TempData.AddSuccessMessage(SuccessfullDeletePriceList(price.Title));
            return RedirectToAction(IndexAction, HomeControllerConst, new { area = AdminArea });
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
