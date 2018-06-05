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
 
            
            public int ArtistId { get; set; }
            public string ArtistName { get; set; }


            public Album()
            {
                this.Singles = new List<Single>();
            }

            public Album(IDataReader reader, Dictionary<int, Artist> dict)
                : this()
            {
                CastFromReader(reader, dict);
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

                        this.ArtistId = Convert.ToInt32(reader["ArtistId"]);
                        this.ArtistName = Convert.ToString(reader["ArtistName"]);

                        if (!dict[this.ArtistId].Albums.Any(x => x.AlbumId == this.AlbumId))
                        {
                            dict[this.ArtistId].Albums.Add(this);
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

                        this.ArtistName = null;
                    }
                }


                //Singles.Add(single);
            }
        }
    }
}
