using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.Models
{
    public class LogEntry
    {
        public int LogEntryId { get; set; }

        public int UserId { get; set; }
        public OfficeUser User { get; set; }

        public DateTime Time { get; set; }
        public ActionDirection Direction { get; set; }
        public string Name { get; set; }
    }
}
