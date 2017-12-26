namespace IvSite.Web.Areas.Blog.Controllers
{
    using System.Threading.Tasks;
    using IvSite.Services.Blog;
    using IvSite.Services.HtmlSanitaizer;
    using IvSite.Web.Areas.Blog.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using IvSite.Data.Models.Users;
    using static WebConstants;
    using static WebHelper;
    using IvSite.Web.Extensions;

    [Area(BlogArea)]
    [Authorize(Roles = AuthorRole)]

    public class HomeController : Controller
    {

        private readonly IBlogArticleService blogArticle;
        private readonly IHtmlSanitizerService html;
        private readonly UserManager<User> userManager;
        public HomeController(IHtmlSanitizerService html, IBlogArticleService blogArticle, UserManager<User> userManager)
        {
            this.html = html;
            this.blogArticle = blogArticle;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        => View(new ArticleListingViewModel
        {
            Articles = await this.blogArticle.AllArticlesAsync(page)
            //TotalArticles = await this.blogArticle.TotalAsync(),
            //Currentpage = page
        });


         //[Authorize(Roles = AdminRole)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Create(CreateArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return View(model);
            }
            model.Content = this.html.Sanitize(model.Content);
            var userId = this.userManager.GetUserId(User);
            await this.blogArticle.CreateAsync(model.Title, model.Content, userId);
            return RedirectToAction(IndexAction, HomeControllerConst, new { area = BlogArea });
        }
    }
}
