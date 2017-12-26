namespace IvSite.Services.PricessList.Models
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models;
    using static IvSite.Data.DataConstants;

    public class AdminCreatePriceListingServicemodel:IMapFrom<PriceList>
    {
        public int Id { get; set; }
        [StringLength(MaxLenTitle, MinimumLength = MinLenTitle)]
        public string Title { get; set; }
        [StringLength(MaxContentLen, MinimumLength = MinContentLen)]
        public string Content { get; set; }

        //public string Admin { get; set; }
        //public void ConfigureMapping(Profile mapper)
        //=> mapper.CreateMap<PriceList, AdminCreatePriceListingServicemodel>()
        //    .ForMember(a => a.Admin, cfg => cfg.MapFrom(a => a.Admin.UserName));
    }
}
