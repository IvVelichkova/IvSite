namespace IvSite.Services.PricessList.Models
{
    using System.ComponentModel.DataAnnotations;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models;
    using static Data.DataConstants;

    public class PriceListDetailsServiceModel:IMapFrom<PriceList>
    {
        public int Id { get; set; }
        [StringLength(MaxLenTitle, MinimumLength = MinLenTitle)]
        public string Title { get; set; }
        [StringLength(MaxContentLen, MinimumLength = MinContentLen)]
        public string Content { get; set; }
    }
}
