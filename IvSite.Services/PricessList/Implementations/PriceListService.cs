using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using IvSite.Data;
using IvSite.Data.Models;
using IvSite.Services.PricessList;
using IvSite.Services.PricessList.Models;
using Microsoft.EntityFrameworkCore;


namespace IvSite.Services.Admin.Implementation
{
    public class PriceListService : IPriceListService
    {
        private readonly IvSiteDbContext db;

        public PriceListService(IvSiteDbContext db)
        {
            this.db = db;
        }


        public async Task CreatePriceListAsync(string title, string content, string adminId)
        {
            var priceList = new PriceList
            {
                Title = title,
                Content = content,
                AdminId = adminId,

            };
            await this.db.AddAsync(priceList);
            await this.db.SaveChangesAsync();
        }

        public async Task<List<AdminCreatePriceListingServicemodel>> AllPriceList()
        {
            var res = await this.db.PriceList.OrderByDescending(d => d.Id).ProjectTo<AdminCreatePriceListingServicemodel>().ToListAsync();
            return res;
        }

       

        public PriceListDetailsServiceModel ById(int id)
        {
           return this.db
               .PriceList
               .Where(a => a.Id == id)
               .ProjectTo<PriceListDetailsServiceModel>()
               .FirstOrDefault();
        }


        public PriceListDetailsServiceModel LastPriceListDetails()
        {
            var id = this.db.PriceList.LastOrDefault().Id;

            var model = this.db.PriceList.Where(i => i.Id == id).Select(s => new PriceListDetailsServiceModel
            {
                Id = s.Id,
                Title = s.Title,
                Content = s.Content
                
            }).FirstOrDefault();

            return model;
        }

        public AdminCreatePriceListingServicemodel FindToDelete(int Id)
        => this.db.PriceList.Where(r => r.Id == Id).ProjectTo<AdminCreatePriceListingServicemodel>().FirstOrDefault();

        public void DeletePriceList(int id, string title, string content)
        {

            {

                var price = this.db.PriceList.Find(id);

                price.Title = title;
                price.Content = content;

                this.db.PriceList.Remove(price);
                this.db.SaveChanges();
            }
        }

    }
}
