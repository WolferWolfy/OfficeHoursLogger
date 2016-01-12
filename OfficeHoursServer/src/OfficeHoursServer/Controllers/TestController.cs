using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeHoursServer.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [Route("api/test/ping")]
        public object Ping()
        {
            return new
            {
                message = "Pong. You accessed an unprotected endpoint."
            };
        }

        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = "Bearer")]
        [Route("api/test/secured/ping")]
        public object SecuredPing()
        {
            return new
            {
                message = "Pong. You accessed a protected endpoint.",
                claims = User.Claims.Select(c => new { c.Type, c.Value })
            };
        }
    }
}
