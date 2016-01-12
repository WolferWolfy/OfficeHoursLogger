using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.Models
{
    public class LogEntry
    {
        public int LogEntryId { get; set; }

        public int DayLogId { get; set; }
        public DayLog DayLog { get; set; }

        public TimeSpan Time { get; set; }
        public ActionDirection Direction { get; set; }
        public string Name { get; set; }
    }
}
