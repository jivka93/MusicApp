using Bytes2you.Validation;
using MusicApp.Services.Contracts;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistService artistService;

        public ArtistController(IArtistService artistService)
        {
            Guard.WhenArgument(artistService, "artistService").IsNull().Throw();
            this.artistService = artistService;
        }

        public string Get()
        {
            var allArtists = this.artistService.GetAll();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(allArtists);
            return json;
        }

        public string Get(int id)
        {
            var artist = this.artistService.GetById(id);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(artist);
            return json;
        }

        // POST: api/Artist
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Artist/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Artist/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
