namespace IvSite.Services.Blog.Implementation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using IvSite.Data;
    using IvSite.Data.Models.Blog;
    using IvSite.Services.Blog.Models;
    using Microsoft.EntityFrameworkCore;

    public class BlogArticleService : IBlogArticleService
    {
        private readonly IvSiteDbContext db;

        public BlogArticleService(IvSiteDbContext db)
        {
            this.db = db;
        }

        public  async Task<IEnumerable<BlogArticleListingServiceModel>> AllArticlesAsync(int page=1)
            =>   await this.db.Articles
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * 5)
                .ProjectTo<BlogArticleListingServiceModel>()
                .ToListAsync();
        

        public async Task CreateAsync(string title, string content,string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                AuthorId = authorId
            };
           this.db.Articles.Add(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
        {
            var total =await this.db.Articles.CountAsync();
            return total;
        }
    }
}
