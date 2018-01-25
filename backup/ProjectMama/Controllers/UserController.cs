using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ProjectMama.Models;

namespace ProjectMama.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public ArrayList Get()
        {
            UserHandler uh = new UserHandler();
            return uh.getUsers();
        }

        // GET: api/User/5
        public User Get(uint id)
        {
            UserHandler uh = new UserHandler();
            return uh.getUser(id);
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]User person)
        {
            UserHandler uh = new UserHandler();
            uint id = uh.saveUser(person);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("person/{0}", id));

            return response;
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(uint id, [FromBody]User person)
        {
            UserHandler uh = new UserHandler();

            if (uh.updateUser(id, person))
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(uint id)
        {
            UserHandler uh = new UserHandler();

            if (uh.deleteUser(id))
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
