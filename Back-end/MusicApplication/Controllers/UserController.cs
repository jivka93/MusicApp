using Bytes2you.Validation;
using MusicApplication.Data;
using MusicApplication.Services.contracts;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicApplication.Controllers
{
    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            this.userService = userService;
        }


        [HttpGet]
        public HttpResponseMessage Get([FromBody]User user)
        {
            var userToRetrun = this.userService.GetUser(user.Username, user.Password);

            if (userToRetrun != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, userToRetrun);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User not found.");
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                var userToReturn = this.userService.CreateUser(user);
                var message = Request.CreateResponse(HttpStatusCode.Created, userToReturn);
                message.Headers.Location = new Uri(Request.RequestUri + userToReturn.UserId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Put(int id, [FromBody]User user)
        {
            try
            {
                var userToReturn = this.userService.UpdateUser(id, user);
                var message = Request.CreateResponse(HttpStatusCode.Accepted, userToReturn);
                message.Headers.Location = new Uri(Request.RequestUri + userToReturn.UserId.ToString());
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
                var result = this.userService.DeleteUser(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Error while deleting the user");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User with Id = {id} not found." + ex);
            }
        }
    }
}
