using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using IvSite.Core.Mapping;
using IvSite.Data.Models;

namespace IvSite.Services.PricessList.Models
{
   public class AdminCreatePriceListingServicemodel:IMapFrom<PriceList>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Admin { get; set; }
        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<PriceList, AdminCreatePriceListingServicemodel>()
            .ForMember(a => a.Admin, cfg => cfg.MapFrom(a => a.Admin.UserName));
    }
}
