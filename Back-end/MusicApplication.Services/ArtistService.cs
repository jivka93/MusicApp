using MusicApplication.Data;
using MusicApplication.Services.contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicApplication.Services
{
    public class ArtistService : IArtistService
    {
        private string connectionString;
        private SqlDataAdapter adapter;

        public ArtistService(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public IEnumerable<Artist> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetAllArtists", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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

                    return artists;
                }
            }
        }


        public Artist GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetArtistById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ArtistId", id);

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

                    return artists[0];
                }
            }
        }


        public Artist UpdateArtist(int id, Artist artist)
        {
            throw new NotImplementedException();
        }


        public Artist CreateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }


        public bool DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }
    }











    //public class ArtistService : IArtistService
    //{
    //    private string connectionString;
    //    private SqlDataAdapter adapter;

    //    public ArtistService(string connectionString)
    //    {
    //        this.connectionString = connectionString;
    //    }

    //    public IEnumerable<Artist> GetAll()
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            DataTable dataTable = new DataTable();
    //            adapter = new SqlDataAdapter("spGetAllArtists", connection);
    //            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            adapter.Fill(dataTable);

    //            var artists = new List<ReadArtist>(dataTable.Rows.Count);

    //            if (dataTable.Rows.Count > 0)
    //            {
    //                foreach (DataRow row in dataTable.Rows)
    //                {
    //                    artists.Add(new ReadArtist(row));
    //                }
    //            }

    //            connection.Close();
    //            return artists;
    //        }
    //    }

    //    public Artist GetById(int id)
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            DataTable dataTable = new DataTable();
    //            adapter = new SqlDataAdapter("spGetArtistById", connection);
    //            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
    //            adapter.Fill(dataTable);

    //            ReadArtist artist;

    //            if (dataTable.Rows.Count == 1)
    //            {
    //                artist = new ReadArtist(dataTable.Rows[0]);
    //                connection.Close();
    //                return artist;
    //            }

    //            connection.Close();
    //            return null;
    //        }
    //    }

    //    public Artist CreateArtist(Artist artist)
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            // Creating the new  artist

    //            adapter = new SqlDataAdapter("spCreateArtist", connection);

    //            var command = new SqlCommand();
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = artist.Name;
    //            command.Parameters.Add("@Label", SqlDbType.NVarChar).Value = artist.Label;
    //            command.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = artist.ImageUrl;

    //            adapter.SelectCommand = command;

    //            adapter.SelectCommand.ExecuteNonQuery();

    //            // Returning the new artist

    //            DataTable dataTable = new DataTable();
    //            adapter = new SqlDataAdapter("spGetLastArtist", connection);
    //            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            adapter.Fill(dataTable);

    //            ReadArtist createdArtist;

    //            if (dataTable.Rows.Count == 1)
    //            {
    //                createdArtist = new ReadArtist(dataTable.Rows[0]);
    //                connection.Close();
    //                return createdArtist;
    //            }

    //            connection.Close();
    //            return null;
    //        }
    //    }

    //    public bool DeleteArtist(int id)
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            // Get the artist
    //            connection.Open();

    //            DataTable dataTable = new DataTable();
    //            adapter = new SqlDataAdapter("spGetArtistById", connection);
    //            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
    //            adapter.Fill(dataTable);

    //            ReadArtist artist;

    //            if (dataTable.Rows.Count == 1)
    //            {
    //                // Delete the artist
    //                artist = new ReadArtist(dataTable.Rows[0]);

    //                adapter = new SqlDataAdapter("spDeleteArtistById", connection);
    //                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
    //                adapter.SelectCommand.ExecuteNonQuery();

    //                connection.Close();
    //                return true;
    //            }

    //            connection.Close();
    //            return false;
    //        }
    //    }

    //    public Artist UpdateArtist(int id, Artist artist)
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            // Get the artist

    //            adapter = new SqlDataAdapter("spUpdateArtist", connection);

    //            var command = new SqlCommand();
    //            command.CommandType = CommandType.StoredProcedure;
    //            command.Parameters.Add("@Id", SqlDbType.Int).Value = artist.Id;
    //            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = artist.Name;
    //            command.Parameters.Add("@Label", SqlDbType.NVarChar).Value = artist.Label;
    //            command.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = artist.ImageUrl;

    //            adapter.SelectCommand = command;

    //            adapter.SelectCommand.ExecuteNonQuery();

    //            // Returning the updated artist

    //            DataTable dataTable = new DataTable();
    //            adapter = new SqlDataAdapter("spGetArtistById", connection);
    //            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
    //            adapter.Fill(dataTable);

    //            ReadArtist updatedArtist;

    //            if (dataTable.Rows.Count == 1)
    //            {
    //                updatedArtist = new ReadArtist(dataTable.Rows[0]);
    //                connection.Close();
    //                return updatedArtist;
    //            }

    //            connection.Close();
    //            return null;
    //        }
    //    }
    //}
}