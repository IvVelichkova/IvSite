
namespace IvSite.Services.Gallery
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IvSite.Services.Gallery.Models;

    public interface IAlbumService
    {
        Task CreateAlbumSRVC(CreateAlbumServiceModel model);
        Task<List<CreateAlbumServiceModel>> AllAlbumsSRVC();
        Task AddPhotoSRVC(CreateAlbumServiceModel model);
        CreateAlbumServiceModel ById(int Id);

    }
}
