using MusicApplication.Data;
using MusicApplication.Data.MusicApplication.Data;

namespace MusicApplication.Services.contracts
{
    public interface IAlbumService
    {
        Artist GetById(int id);

        Album CreateAlbum(Album album);

        Album UpdateAlbum(int id, Album album);

        bool DeleteAlbum(int id);
    }
}
