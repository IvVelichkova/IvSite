﻿namespace IvSite.Web.Areas.Admin.Controllers
{
    using System;
    using System.Threading.Tasks;
    using IvSite.Data.Models.TypesRoom;
    using IvSite.Data.Models.Users;
    using IvSite.Services.Admin.Models.Rooms;
    using IvSite.Web.Areas.Admin.Models.Rooms;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using static WebConstants;
    using IvSite.Services;
    using IvSite.Web.Extensions;

    public class RoomsController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IRoomService rooms;
        private readonly RoleManager<IdentityRole> roleManager;

        //public const string RedirectToHome = $"\"Index""," "Home"", new { area = "" });");

        public RoomsController(UserManager<User> userManager, IRoomService rooms,RoleManager<IdentityRole> roleManager)
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
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            return View(new EditRoomServiceModel());
           
        }

        [HttpPost]
        public IActionResult Edit(int id,EditRoomServiceModel room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }
            if (!User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            

            this.rooms.Edit(
                id,
                room.Name,
                room.Capacity,
                room.LuxStatus,
                room.Smokers);

            TempData.AddSuccessMessage($"You successfully edit room {room.Name}");
            return RedirectToAction(nameof(Create));

        }

        public async Task<IActionResult> AllRooms()
        {
            var roooms = await this.rooms.AllRooms();

            return View(new AllRoomsViewModel()
            {
                Rooms =roooms
            });
            
        }
    }
}
