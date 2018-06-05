using MusicApplication.Data;
using MusicApplication.Data.MusicApplication.Data;
using MusicApplication.Services.contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicApplication.Services
{
    public class AlbumService : IAlbumService
    {
        private string connectionString;

        public AlbumService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Artist GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetAlbumById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AlbumId", id);

                    connection.Open();

                    var dict = new Dictionary<int, Artist>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var artist = new Artist(reader, dict);

                            if (!dict.ContainsKey(artist.ArtistId))
                            {
                                dict.Add(artist.ArtistId, artist);
                            }
                        }
                    }

                    var artists = new List<Artist>();
                    foreach (var item in dict)
                    {
                        artists.Add(item.Value);
                    }

                    if (artists.Count > 0)
                    {
                        return artists[0];
                    }

                    return null;
                }
            }
        }


        public Album UpdateAlbum(int id, Album Album)
        {
            throw new NotImplementedException();
        }


        public Album CreateAlbum(Album Album)
        {
            throw new NotImplementedException();
        }


        public bool DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }
    }
}
