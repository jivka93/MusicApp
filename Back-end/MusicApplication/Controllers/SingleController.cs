using Bytes2you.Validation;
using MusicApplication.Data;
using MusicApplication.Services.contracts;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicApplication.Controllers
{
    public class SingleController : ApiController
    {
        private ISingleService singleService;

        public SingleController(ISingleService singleService)
        {
            Guard.WhenArgument(singleService, "singleService").IsNull().Throw();
            this.singleService = singleService;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var single = this.singleService.GetById(id);

            if (single != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, single);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Single with Id = {id} not found.");
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Single single)
        {
            try
            {
                this.singleService.CreateSingle(single);
                var message = Request.CreateResponse(HttpStatusCode.Created, single);
                message.Headers.Location = new System.Uri(Request.RequestUri + single.SingleId.ToString());
                return message;
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Put(int id, [FromBody]Single single)
        {
            try
            {
                this.singleService.UpdateSingle(id, single);
                var message = Request.CreateResponse(HttpStatusCode.Accepted, single);
                message.Headers.Location = new System.Uri(Request.RequestUri + single.SingleId.ToString());
                return message;
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                this.singleService.DeleteSingle(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Single with Id = {id} not found." + ex);
            }
        }
    }
}
