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
    using static WebHelper;


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
                TempData.AddErrorMessage(ErrorModelState());
                return View(room);
            }

            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            this.rooms
                  .Create(room.Name,
                  room.Capacity,
                  room.LuxStatus,
                  room.Smokers);
            TempData.AddSuccessMessage(SuccessCreateNewRoom);

            return RedirectToAction(IndexAction, HomeControllerConst, new { area = AdminArea });


        }

        public IActionResult Edit(int id)
        {

            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            var model = this.rooms.FindToEdit(id);

            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, EditRoomServiceModel room)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return View(room);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            this.rooms.Edit(
               room);

            TempData.AddSuccessMessage(SuccessfullEditedRoom(room.Name));
            return RedirectToAction(IndexAction, HomeControllerConst, new { area = AdminArea });
        }

        public async Task<IActionResult> AllRooms()
        {
            var roooms = await this.rooms.AllRooms();


            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            return View(new AllRoomsViewModel
            {
                Rooms = roooms
            });

        }


        public IActionResult DeleteRoom(int id)
        {

            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }
            var model = this.rooms.FindToEdit(id);

            return View(model);

        }



        [HttpPost]
        public IActionResult DeleteRoom(int id, EditRoomServiceModel room)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return View(room);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction(HomeIndex);
            }

                      
            this.rooms.DeleteRoomService(
               room);
            TempData.AddSuccessMessage(SuccessDeleteRomRoom);

            return RedirectToAction(IndexAction, HomeControllerConst, new { area = AdminArea });
        }
    }
}
