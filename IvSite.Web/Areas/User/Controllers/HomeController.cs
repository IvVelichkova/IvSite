using System.Collections.Generic;
using System.Threading.Tasks;
using IvSite.Services;
using IvSite.Services.User.Models;
using IvSite.Web.Areas.Admin.Models.Rooms;
using IvSite.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace IvSite.Web.Areas.User.Controllers
{
    public class HomeController:BaseController
    {
        private readonly IUserService user;
        private readonly IRoomService rooms;

        public HomeController(IUserService user,IRoomService rooms)
        {
            this.user = user;
            this.rooms = rooms;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int id)
        {
            return View();
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
