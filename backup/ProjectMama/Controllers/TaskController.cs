using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectMama.Controllers
{
    public class TaskController : ApiController
    {
        // GET: api/Task
        public ArrayList Get()
        {
            TaskHandler th = new TaskHandler();
            return th.getTasks();
        }

        // GET: api/Task/5
        public Task Get(uint id)
        {
            TaskHandler th = new TaskHandler();
            return th.getTask(id);
        }

        // POST: api/Task
        public HttpResponseMessage Post([FromBody]Task person)
        {
            TaskHandler th = new TaskHandler();
            uint id = th.saveTask(person);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("task/{0}", id));

            return response;
        }

        // PUT: api/Task/5
        public HttpResponseMessage Put(uint id, [FromBody]Task person)
        {
            TaskHandler th = new TaskHandler();

            if (th.updateTask(id, person))
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE: api/Task/5
        public HttpResponseMessage Delete(uint id)
        {
            TaskHandler th = new TaskHandler();

            if (th.deleteTask(id))
                return Request.CreateResponse(HttpStatusCode.NoContent);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
