namespace IvSite.Web.Areas.User.Controllers
{
    using System;
    using System.Threading.Tasks;
    using IvSite.Services.Admin;
    using IvSite.Services.Reserve;
    using IvSite.Services.User;
    using IvSite.Web.Areas.Users.Models;
    using IvSite.Web.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;
    using static WebHelper;

    public class HomeController:BaseController
    {
        private readonly IUserService user;
        private readonly IRoomService rooms;
        private readonly IReserveService reserve;

        public HomeController(IUserService user,IRoomService rooms,IReserveService reserve)
        {
            this.user = user;
            this.rooms = rooms;
            this.reserve = reserve;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int id)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
            }
            return View();
        }
        public async Task<IActionResult> BookingForm()
        {
            var roooms = await this.rooms.AllRooms();


            return View(new BookingForm
            {
                StartDate = DateTime.UtcNow.Date,
                EndDate=DateTime.UtcNow.AddDays(1),
                Rooms = roooms
            });

        }

        public IActionResult FreeRooms()
        {

            var model = new BookingForm
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1)
                
            };
           
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FreeRooms(BookingForm model)
        {

            var rooms = await this.user.AllFreeRooms(model.StartDate,model.EndDate);
           var newModel = new BookingForm
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Rooms = rooms
            };

            return View(newModel);


        }
      

    }
}
