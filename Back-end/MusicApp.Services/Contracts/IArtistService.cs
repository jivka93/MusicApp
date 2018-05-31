using MusicApp.Data;
using System.Collections.Generic;

namespace MusicApp.Services.Contracts
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();

        Artist GetById(int id);

        void CreateArtist(Artist artist);

        void UpdateArtist(Artist artist);

        void DeleteArtist(Artist artist);

        void DeleteArtist(int id);
    }
}
