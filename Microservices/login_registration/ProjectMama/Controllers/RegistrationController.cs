﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectMama.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationController : ApiController
    {
        // POST: api/Registration
        public HttpResponseMessage Post([FromBody]User user)
        {
            RegistrationHandler rh = new RegistrationHandler();
            uint id = rh.saveUser(user);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("user/{0}", id));

            return response;
        }
    }
}
