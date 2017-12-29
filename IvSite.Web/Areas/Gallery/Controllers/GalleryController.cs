namespace IvSite.Web.Areas.Gallery.Controllers
{
    using IvSite.Web.Areas.Gallery.Models;
    using IvSite.Web.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using IvSite.Data.Models.Users;
    using static WebConstants;
    using static WebHelper;
    using IvSite.Services.Gallery;
    using IvSite.Services.Gallery.Models;
    using System.Threading.Tasks;

    [Authorize]
    [Area(AreaGallery)]
    public class GalleryController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IAlbumService albumService;

        public GalleryController(UserManager<User> userManager
            , IAlbumService albumService)
        {
            this.userManager = userManager;
            this.albumService = albumService;
        }



        public async Task<IActionResult> Index()
        {
            var albums = await this.albumService.AllAlbumsSRVC();
            return View(albums);
        }

        [Authorize(Roles = AuthorRole)]
        public IActionResult CreateAlbum()
        {
            if (!User.IsInRole(AuthorRole))
            {
                RedirectToAction(HomeIndex);
            }
            return View();
        }

        [Authorize(Roles = AuthorRole)]
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumServiceModel model)
        {
            model.AuthorId = this.userManager.GetUserId(User);


            if (!User.IsInRole(AuthorRole))
            {
                RedirectToAction(HomeIndex);
            }
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return View(model);
            }
            await this.albumService.CreateAlbumSRVC(model);
            return RedirectToAction(IndexAction);

        }
        public async Task<IActionResult> DetailsAlbum(int id)
        {

            var model = new DetailsAlbumServiceModel();
            var photos = await this.albumService.All(id);
            model.Photos = photos;
            //model.Photos = photos;
               
            return View(model);
        }

        public IActionResult AddPhotos(int id)
        {
            if (!User.IsInRole(AuthorRole))
            {
                return RedirectToAction(HomeIndex);
            }
            var model = this.albumService.ById(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPhotos(CreateAlbumServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.AddErrorMessage(ErrorModelState());
                return View(model);
            }
            if (!User.IsInRole(AuthorRole))
            {
                return RedirectToAction(HomeIndex);
            }
            await this.albumService.AddPhotoSRVC(model);

            TempData.AddSuccessMessage(SuccessAddPhoto);

            return RedirectToAction(IndexAction, GalleryControllerConst, new { area = AreaGallery });
        }

        public IActionResult Comment(CreatePhotoServiceModel model)
        {
            var photoId = model.Id;
            var res = albumService.PhotoById(photoId);

            return View(res);
        }

        //[HttpPost]
        //public JsonResult Comment([FromBody]CreateCommentServiceModel model)
        //{
        //    var userId = userManager.GetUserId(User);
        //    var comment=new CreateCommentServiceModel {
        //        Content=model.Content,
        //        UserId=userId,
                
                
        //    }
        //    //return Json(albumService.CreateComment(model.UserId, model.Commens));
        //}

    }
}
