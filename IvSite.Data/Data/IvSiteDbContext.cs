namespace IvSite.Data
{
    using IvSite.Data.Models;
    using IvSite.Data.Models.Blog;
    using IvSite.Data.Models.Gallery;
    using IvSite.Data.Models.Rooms;
    using IvSite.Data.Models.Users;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class IvSiteDbContext : IdentityDbContext<User>
    {
        public IvSiteDbContext(DbContextOptions<IvSiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reserve { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<PriceList> PriceList { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reservation>()
                .HasOne(u => u.Guest)
                .WithMany(r => r.Reservations)
                .HasForeignKey(g => g.GuestId);

            builder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(rs => rs.Reservations)
                .HasForeignKey(r => r.RoomId);

            builder.Entity<Article>()
                .HasOne(u => u.Author)
                .WithMany(ar => ar.Articles)
                .HasForeignKey(a => a.AuthorId);

            builder.Entity<PriceList>()
                .HasOne(a => a.Admin)
                .WithMany(p => p.PriceList)
                .HasForeignKey(ad => ad.AdminId);

            builder.Entity<Photo>()
                .HasOne(a => a.Album)
                .WithMany(p => p.Photos)
                .HasForeignKey(al => al.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Comment>()
                .HasOne(i => i.Photo)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.UserId);


            builder.Entity<Album>()
                 .HasOne(u => u.Author)
                 .WithMany(al => al.Albums)
                 .HasForeignKey(a => a.AuthorId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
