namespace IvSite.Services.Blog.Models
{
    using AutoMapper;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Blog;

    public class BlogArticleListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }


        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Article, BlogArticleListingServiceModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
