namespace IvSite.Services.Blog.Models
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using IvSite.Core.Mapping;
    using IvSite.Data.Models.Blog;
    using static Data.DataConstants;

    public class BlogArticleListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [StringLength(MaxLenTitle, MinimumLength = MinLenTitle)]
        public string Title { get; set; }

        [StringLength(MaxContentLen, MinimumLength = MinContentLen)]
        public string Content { get; set; }

        public string Author { get; set; }


        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Article, BlogArticleListingServiceModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
