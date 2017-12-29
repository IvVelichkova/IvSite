namespace IvSite.Services.Gallery.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using IvSite.Data;
    using IvSite.Data.Models.Gallery;
    using IvSite.Services.Gallery.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using IvSite.Data.Models.Users;
    using System.Linq;

    public class AlbumService : IAlbumService
    {
        private readonly IvSiteDbContext db;
        private readonly UserManager<User> userManager;

        public AlbumService(IvSiteDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<List<CreateAlbumServiceModel>> AllAlbumsSRVC()
        => await this.db.Albums
            .OrderByDescending(d => d.Id)
            .ProjectTo<CreateAlbumServiceModel>()
            .ToListAsync();


        public async Task<List<CreatePhotoServiceModel>> AllPhotosSRVC(int albumId)
             => await this.db.Photos.Where(a => a.AlbumId == albumId).ProjectTo<CreatePhotoServiceModel>().ToListAsync();

        public async Task<List<CreatePhotoServiceModel>> All(int idAl)
        {
            var res = await this.db
                   .Photos.Select(r=>r).Where
                   (h => h.AlbumId == idAl).ProjectTo<CreatePhotoServiceModel>().ToListAsync();
            return res;
        }



        public async Task CreateAlbumSRVC(CreateAlbumServiceModel model)
        {

            var album = new Album
            {

                AuthorId = model.AuthorId,
                Title = model.Title
            };

            await this.db.Albums.AddAsync(album);
            await this.db.SaveChangesAsync();
        }
        public async Task AddPhotoSRVC(CreateAlbumServiceModel model)
        {
            var album = this.db.Albums.Find(model.Id);
            var photo = new Photo
            {
                Name = model.PhotoName,
                Url = model.PhotoUrl
            };

            var res = this.db.Albums.Where(i => i.Id == model.Id).SingleOrDefault();
            res.Photos.Add(photo);
            await this.db.SaveChangesAsync();
        }



        public CreateAlbumServiceModel ById(int Id) => this.db.Albums.Where(r => r.Id == Id).ProjectTo<CreateAlbumServiceModel>().SingleOrDefault();

        public CreatePhotoServiceModel PhotoById(int Id) => this.db.Photos.Where(i => i.Id == Id).ProjectTo<CreatePhotoServiceModel>().SingleOrDefault();
        
    }
}
