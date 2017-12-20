namespace IvSite.Web.Areas.User.Controllers
{
    using IvSite.Services;
    using IvSite.Services.User.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using IvSite.Data.Models.Users;
    using IvSite.Web.Extensions;
    using IvSite.Services.Reserve;

    public class RoomController:BaseController
    {
        private readonly IReserveService reserve;
        private readonly UserManager<User> userManager;

        public RoomController(IReserveService reserve,UserManager<User> userManager)
        {
            this.reserve = reserve;
            this.userManager = userManager;
        }

        [HttpPost]
        public IActionResult CreateBooking(ReservationsServiceModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.FreeRooms), "Home");
            }
            this.reserve.CreateBookingUser(model.RoomId, this.userManager.GetUserId(this.User), model.StartDate, model.EndDate, model.Note);

            TempData.AddSuccessMessage($"You successfully  Booked from {model.StartDate.ToShortDateString()} to {model.EndDate.ToShortDateString()}");
            return RedirectToAction(nameof(HomeController.FreeRooms), "Home");
        }
    }
}
