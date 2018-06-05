using MusicApplication.Data;
using System.Collections.Generic;

namespace MusicApplication.Services.contracts
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();

        Artist GetById(int id);

        Artist CreateArtist(Artist artist);

        Artist UpdateArtist(int id, Artist artist);

        bool DeleteArtist(int id);
    }
}
