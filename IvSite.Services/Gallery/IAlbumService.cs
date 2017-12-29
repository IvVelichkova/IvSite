
namespace IvSite.Services.Gallery
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Services.Gallery.Models;

    public interface IAlbumService
    {
        Task CreateAlbumSRVC(CreateAlbumServiceModel model);
        Task AddPhotoSRVC(CreateAlbumServiceModel model);
        Task<List<CreateAlbumServiceModel>> AllAlbumsSRVC();
        Task<List<CreatePhotoServiceModel>> AllPhotosSRVC(int albumId);
        Task<List<CreatePhotoServiceModel>> All(int idAl);

        CreateAlbumServiceModel ById(int Id);
        CreatePhotoServiceModel PhotoById(int Id);

    }
}
