using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IvSite.Web.WebConstants;

namespace IvSite.Web
{
    public static class WebHelper
    {
        public static string UserAddedSuccessFullToRole(string userName, string role)
        {
            return $"User {userName} successfully added  to {role}";
        }
        public static string ErrorModelState()
        {
            return $"ModelState is not valid";
        }
        public static string SuccessfullCreatePriceList(string priceListTitle)
        {
            return $"You successfully Create New Price List { priceListTitle } ";
        }

        public static string SuccessfullDeletePriceList(string priceListTitle)
        {
            return $"You successfully Delete Price List { priceListTitle } ";
        }

        public static string SuccessfullEditedRoom(string roomName)
        {
            return
            $"You successfully edit room {roomName}";
        }
        public static string AreaAdminHomeIndex()
        {
            return (IndexAction, HomeControllerConst, new { area = AdminArea }).ToString();
        }

        public static string AreaBlogHomeIndex()
        {
            return (IndexAction, HomeControllerConst, new { area = BlogArea }).ToString();
        }

        public static string SuccessBooking(DateTime start,DateTime end)
        {
            return $"You successfully  Booked from {start.ToShortDateString()} to {end.ToShortDateString()}";
            
        }
    }
}
