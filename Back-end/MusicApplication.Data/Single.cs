﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MusicApplication.Data
{
    public class Single// : IDataModel
    {
        public int? SingleId { get; set; }

        public string SingleName { get; set; }

        public string SingleUrl { get; set; }

    

        public void CastFromReader(IDataReader reader, Dictionary<int, Artist> dict)
        {
            if ((Convert.ToString(reader["SingleName"])) != null && (Convert.ToString(reader["SingleName"])) != string.Empty)
            {
                try
                {
                    this.SingleId = Convert.ToInt32(reader["SingleId"]);
                    this.SingleName = (string)reader["SingleName"];
                    this.SingleUrl = (string)reader["SingleUrl"];

                    var artistId = Convert.ToInt32(reader["ArtistId"]);
                    var albumId = Convert.ToInt32(reader["AlbumId"]);

                    if (!dict[artistId].Albums.Where(a => a.AlbumId == albumId).FirstOrDefault().Singles.Any(s => s.SingleId == this.SingleId))
                    {
                        dict[artistId].Albums.Where(a => a.AlbumId == albumId).FirstOrDefault().Singles.Add(this);
                    }
                }
                catch (Exception)
                {
                    this.SingleId = null;
                    this.SingleName = null;
                    this.SingleUrl = null;
                }
            }
        }
    }

}