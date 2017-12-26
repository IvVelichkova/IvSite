namespace IvSite.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class WebConstants
    {
        public const string AdminRole = "Admin";

        public const string AuthorRole = "Author";

        public const string GuestRole = "Guest";

        public const string BlogArea = "Blog";

        public const string AdminArea = "Admin";

        public const string UserArea = "User";

        public const string AreaGallery = "Gallery";

        public const string IvSite = "IvSite";

        public const string TempDataSuccess = "SuccessMessage";

        public const string InvalidIdentityDetails = "Invalid Identity details";

        public const string TempDateError = "ErrorMessage";

        public const string IndexAction = "Index";

        public const string HomeControllerConst = "Home";

        public const string GalleryControllerConst = "Gallery";

        public const string SuccessCreateNewRoom = "You Successfull Created New Room";

        public const string SuccessDeleteRomRoom = "You Successfull Delete Room";

        public const string SuccessAddPhoto= "You Successfull Add New Photo";

        public const string AreaBlogHomeIndex = "Index" + "," + "Home" + "," + "new" + " {" + " area" + "=" + "Blog" + "}";

        public const string HomeIndex = "Index" + "," + "Home" + "," + "new" + "{" + "area" + "=" + "" + "}";

    }
}
