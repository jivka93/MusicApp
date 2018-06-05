using Bytes2you.Validation;
using MusicApplication.Data.MusicApplication.Data;
using MusicApplication.Services.contracts;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicApplication.Controllers
{
    public class AlbumController : ApiController
    {
        private IAlbumService albumService;

        public AlbumController(IAlbumService albumService)
        {
            Guard.WhenArgument(albumService, "albumService").IsNull().Throw();
            this.albumService = albumService;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var album = this.albumService.GetById(id);

            if (album != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, album);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Album with Id = {id} not found.");
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Album album)
        {
            try
            {
                this.albumService.CreateAlbum(album);
                var message = Request.CreateResponse(HttpStatusCode.Created, album);
                message.Headers.Location = new Uri(Request.RequestUri + album.AlbumId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Put(int id, [FromBody]Album album)
        {
            try
            {
                this.albumService.UpdateAlbum(id, album);
                var message = Request.CreateResponse(HttpStatusCode.Accepted, album);
                message.Headers.Location = new Uri(Request.RequestUri + album.AlbumId.ToString());
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
                this.albumService.DeleteAlbum(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Album with Id = {id} not found." + ex);
            }
        }

    }
}
