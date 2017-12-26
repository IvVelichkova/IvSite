namespace IvSite.Web.Areas.User.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;

    [Area(UserArea)]
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}