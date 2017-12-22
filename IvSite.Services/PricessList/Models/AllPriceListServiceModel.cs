namespace IvSite.Services.PricessList.Models
{
    using System.Collections.Generic;

    public class AllPriceListServiceModel
    {
        public IEnumerable<AdminCreatePriceListingServicemodel> PriceLists { get; set; }
    }
}
