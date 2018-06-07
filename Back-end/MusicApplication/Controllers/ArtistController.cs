using Bytes2you.Validation;
using MusicApplication.Data;
using MusicApplication.Services.contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicApplication.Controllers
{
    public class ArtistController : ApiController
    {
        private IArtistService artistService;

        public ArtistController(IArtistService artistService)
        {
            Guard.WhenArgument(artistService, "artistService").IsNull().Throw();
            this.artistService = artistService;
        }

        [HttpGet]
        public IEnumerable<Artist> Get()

        {
            return this.artistService.GetAll();
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var artist = this.artistService.GetById(id);

            if (artist != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, artist);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Artist with Id = {id} not found.");
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Artist artist)
        {
            try
            {
                var artistToRetrun = this.artistService.CreateArtist(artist);
                var message = Request.CreateResponse(HttpStatusCode.Created, artistToRetrun);
                message.Headers.Location = new Uri(Request.RequestUri + artistToRetrun.ArtistId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Put(int id, [FromBody]Artist artist)
        {
            try
            {
                var artistToReturn = this.artistService.UpdateArtist(id, artist);
                var message = Request.CreateResponse(HttpStatusCode.Accepted, artistToReturn);
                message.Headers.Location = new Uri(Request.RequestUri + artistToReturn.ArtistId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                bool result = this.artistService.DeleteArtist(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Artist with Id = {id} not found.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Artist with Id = {id} not found." + ex);
            }
        }
    }
}
