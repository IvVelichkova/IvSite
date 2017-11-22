namespace IvSite.Data
{
    using IvSite.Data.Models.Users;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class IvSiteDbContext : IdentityDbContext<User>
    {
        public IvSiteDbContext(DbContextOptions<IvSiteDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
