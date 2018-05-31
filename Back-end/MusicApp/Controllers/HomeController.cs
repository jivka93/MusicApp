using Bytes2you.Validation;
using MusicApp.Data;
using MusicApp.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class HomeController : Controller
    {
        public IArtistService ArtistService { get; set; }

        public string Index()
        {
            var allArtists = this.ArtistService.GetAll();
            var json = JsonConvert.SerializeObject(allArtists);
            return json;
        }       

    }
}