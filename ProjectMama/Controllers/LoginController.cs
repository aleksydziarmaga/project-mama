using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using ProjectMama.Models;

namespace ProjectMama.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginInfo
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginController : ApiController
    {
        // POST: api/Login
        public bool Post(LoginInfo logInfo)
        {
            LoginHandler lh = new LoginHandler();
            return lh.checkLoginRequest(logInfo.username, logInfo.password);
        }
    }
}
