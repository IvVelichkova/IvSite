namespace IvSite.Services.Blog
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Services.Blog.Models;

    public interface IBlogArticleService
    {
        Task<IEnumerable<BlogArticleListingServiceModel>> AllArticlesAsync(int page=1);
        Task<int> TotalAsync();
        Task CreateAsync(string title, string content,string authorId);
    }
}
