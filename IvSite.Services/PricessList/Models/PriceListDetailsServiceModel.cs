using System;
using System.Collections.Generic;
using System.Text;
using IvSite.Core.Mapping;
using IvSite.Data.Models;

namespace IvSite.Services.PricessList.Models
{ 
   public class PriceListDetailsServiceModel:IMapFrom<PriceList>
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public string Content { get; set; }
    }
}
