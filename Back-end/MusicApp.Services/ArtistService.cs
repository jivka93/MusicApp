using MusicApp.Data;
using MusicApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicApp.Services
{
    public class ArtistService : IArtistService
    {
        private string connectionString;
        private SqlDataAdapter adapter;

        // TODO move connectionString
        public ArtistService(string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;")
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Artist> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                adapter = new SqlDataAdapter("spGetAllArtists", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(dataTable);

                var artists = new List<ReadArtist>(dataTable.Rows.Count);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        artists.Add(new ReadArtist(row));
                    }
                }

                connection.Close();
                return artists;
            }
        }

        public Artist GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable dataTable = new DataTable();
                adapter = new SqlDataAdapter("spGetArtistById", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                adapter.Fill(dataTable);

                ReadArtist artist;

                if (dataTable.Rows.Count == 1)
                {
                    artist = new ReadArtist(dataTable.Rows[0]);
                    connection.Close();
                    return artist;
                }

                return null;
            }
        }

        public void CreateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void DeleteArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
