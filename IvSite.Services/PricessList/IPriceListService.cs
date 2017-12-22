namespace IvSite.Services.PricessList
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Services.PricessList.Models;

    public interface  IPriceListService
    {
        Task CreatePriceListAsync(string title, string content, string adminId);
        Task<List<AdminCreatePriceListingServicemodel>> AllPriceList();
        AdminCreatePriceListingServicemodel FindToEdit(int Id);
        void EditPriceList(int id, string title, string content);
         PriceListDetailsServiceModel ById(int id);
        PriceListDetailsServiceModel LastPriceListDetails();
        AdminCreatePriceListingServicemodel FindToDelete(int Id);
        void DeletePriceList(int id, string title, string content);


    }
}
