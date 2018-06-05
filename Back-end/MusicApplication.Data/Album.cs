using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MusicApplication.Data
{
    namespace MusicApplication.Data
    {
        public class Album //: IDataModel
        {
            public int? AlbumId { get; set; }

            public string AlbumName { get; set; }

            public string AlbumImageUrl { get; set; }

            public DateTime? Year { get; set; }

            public List<Single> Singles { get; set; }


            public Album()
            {
                this.Singles = new List<Single>();
            }

            public void CastFromReader(IDataReader reader, Dictionary<int, Artist> dict)
            {
                if ((Convert.ToString(reader["AlbumName"])) != string.Empty)
                {
                    try
                    {
                        this.AlbumId = Convert.ToInt32(reader["AlbumId"]);
                        this.AlbumName = Convert.ToString(reader["AlbumName"]);
                        this.AlbumImageUrl = Convert.ToString(reader["AlbumImageUrl"]);
                        this.Year = Convert.ToDateTime(reader["Year"]);

                        var artistId = Convert.ToInt32(reader["ArtistId"]);

                        if (!dict[artistId].Albums.Any(x => x.AlbumId == this.AlbumId))
                        {
                            dict[artistId].Albums.Add(this);
                        }

                        var single = new Single();
                        single.CastFromReader(reader, dict);
                    }
                    catch (Exception)
                    {
                        this.AlbumId = null;
                        this.AlbumName = null;
                        this.AlbumImageUrl = null;
                        this.Year = null;
                        this.Singles = null;
                    }
                }


                //Singles.Add(single);
            }
        }
    }
}
