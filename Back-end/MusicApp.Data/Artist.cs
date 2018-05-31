using System;
using System.Data;

namespace MusicApp.Data
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string ImageUrl { get; set; }
    }

    public class ReadArtist : Artist
    {
        public ReadArtist(DataRow row)
        {
            this.Id = Convert.ToInt32(row["Id"]);
            this.Name = row["Name"].ToString();
            this.Label = row["Label"].ToString();
            this.ImageUrl = row["ImageUrl"].ToString();
        }
    }

    public class CreateArtist : Artist
    {

    }
}
