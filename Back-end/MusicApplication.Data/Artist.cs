using MusicApplication.Data.MusicApplication.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace MusicApplication.Data
{
    public class Artist // : IDataModel
    {
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public string Label { get; set; }

        public string ArtistImageUrl { get; set; }

        public List<Album> Albums { get; set; }


        public Artist()
        {
            this.Albums = new List<Album>();
        }

        public Artist(IDataReader reader, Dictionary<int, Artist> dict)
            : this()
        {
            CastFromReader(reader, dict);
        }


        public void CastFromReader(IDataReader reader, Dictionary<int, Artist> dict)
        {
            this.ArtistId = Convert.ToInt32(reader["ArtistId"]);
            this.ArtistName = Convert.ToString(reader["ArtistName"]);
            this.Label = Convert.ToString(reader["Label"]);
            this.ArtistImageUrl = Convert.ToString(reader["ArtistImageUrl"]);


            if (!dict.ContainsKey(this.ArtistId))
            {
                dict.Add(this.ArtistId, this);
            }

            var album = new Album();
            album.CastFromReader(reader, dict);
        }
    }
}