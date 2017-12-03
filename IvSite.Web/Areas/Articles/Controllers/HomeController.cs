namespace IvSite.Web.Areas.Articles.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ArticlesBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
