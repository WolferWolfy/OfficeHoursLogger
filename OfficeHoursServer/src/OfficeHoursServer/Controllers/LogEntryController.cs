using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OfficeHoursServer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeHoursServer.Controllers
{
    public class LogEntryController : Controller
    {
        [FromServices]
        public OfficeHoursContext OfficeHoursContext { get; set; }

        [FromServices]
        public ILogger<LogEntryController> Logger { get; set; }


        [HttpGet]
        [Route("api/logentry/ping")]
        public object Ping()
        {
            var entryList = OfficeHoursContext.LogEntries.Include(le => le.DayLog).ToList();
            return new
            {
                message = "Pong. You accessed an unprotected endpoint.",
                entries = entryList.Count
            };
        }

        [Route("api/logentry/entries")]
        public List<LogEntry> Entries()
        {
            var entryList = OfficeHoursContext.LogEntries.Include(le => le.DayLog).ToList();

            var b = new List<LogEntry>();
            b.Add(new LogEntry()
            {
                Name = "A"
            });

            b.Add(new LogEntry()
            {
                Name = "B"
            });


            return entryList;
        }
    }
}
