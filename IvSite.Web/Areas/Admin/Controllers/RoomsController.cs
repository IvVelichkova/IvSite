namespace IvSite.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using IvSite.Data.Models.Users;
    using IvSite.Services.Admin.Models.Rooms;
    using IvSite.Web.Areas.Admin.Models.Rooms;
    using Microsoft.AspNetCore.Identity;
    using IvSite.Web.Extensions;
    using IvSite.Services.Admin;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;


    public class RoomsController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IRoomService rooms;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoomsController(UserManager<User> userManager, IRoomService rooms, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.rooms = rooms;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Create()
        {
            var admins = await this.userManager
                .GetUsersInRoleAsync(AdminRole);
            return View(new CreateRoomServiceModel());
        }
        [HttpPost]
        public IActionResult Create(CreateRoomServiceModel room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }

            this.rooms
                  .Create(room.Name,
                  room.Capacity,
                  room.LuxStatus,
                  room.Smokers);
            return RedirectToAction("Index", "Home", new { area = "" });

        }

        public IActionResult Edit(int id)
        {

            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            var model = this.rooms.FindToEdit(id);
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, EditRoomServiceModel room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            this.rooms.Edit(
               room);

            TempData.AddSuccessMessage($"You successfully edit room {room.Name}");
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        public async Task<IActionResult> AllRooms()
        {
            var roooms = await this.rooms.AllRooms();


            return View(new AllRoomsViewModel
            {
                Rooms = roooms
            });


        }
    }
}
