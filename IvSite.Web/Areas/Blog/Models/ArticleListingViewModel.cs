namespace IvSite.Web.Areas.Blog.Models
{
    using System;
    using System.Collections.Generic;
    using IvSite.Services.Blog.Models; 

    public class ArticleListingViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Articles { get; set; }
        public int TotalArticles { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)this.TotalArticles / 5);
        public int Currentpage { get; set; }
        public int Previouspage => this.Currentpage == 1 ? 1 : this.Currentpage - 1;
        private int NextPage => this.Currentpage == this.TotalPages ? this.TotalPages : this.Currentpage + 1;
    }
}
