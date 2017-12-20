namespace IvSite.Web.Areas.Blog.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    [Area("Blog")]
    [Authorize(Roles =AuthorRole)]
    [Authorize(Roles =AdminRole)]
    public class BaseController : Controller
    {
    }
}
