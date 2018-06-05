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
                this.artistService.CreateArtist(artist);
                var message = Request.CreateResponse(HttpStatusCode.Created, artist);
                message.Headers.Location = new Uri(Request.RequestUri + artist.ArtistId.ToString());
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
                this.artistService.UpdateArtist(id, artist);
                var message = Request.CreateResponse(HttpStatusCode.Accepted, artist);
                message.Headers.Location = new Uri(Request.RequestUri + artist.ArtistId.ToString());
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
                this.artistService.DeleteArtist(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Artist with Id = {id} not found." + ex);
            }
        }
    }

}
