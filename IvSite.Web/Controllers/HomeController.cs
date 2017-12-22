using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IvSite.Web.Models;
using Microsoft.AspNetCore.Authorization;
using IvSite.Services.Admin;
using IvSite.Services.PricessList;

namespace IvSite.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly IPriceListService price;

        public HomeController(IPriceListService price)
        {
            this.price = price;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult DetailsPriceList()
        {
            var model = this.price.LastPriceListDetails();
            return View(model);
        }

    }
}
