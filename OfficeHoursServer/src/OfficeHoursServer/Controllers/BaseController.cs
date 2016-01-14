using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OfficeHoursServer.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeHoursServer.Controllers
{

    public class BaseController : Controller
    {
        [FromServices]
        public OfficeHoursContext OfficeHoursContext { get; set; }

        [FromServices]
        public ILogger<LogEntryController> Logger { get; set; }


        public OfficeUser LoggedInUser { get { return OfficeHoursContext.Users.Where(u => u.Email.Equals(GetUserEmail())).FirstOrDefault() ; } }

        private string GetUserEmail()
        {
            return User.Claims.Where(c => c.Type.Equals("name")).Select(c => c.Value).FirstOrDefault();
        }
    }

}
