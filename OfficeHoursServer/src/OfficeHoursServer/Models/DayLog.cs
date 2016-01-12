using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.Models
{
    public class DayLog
    {
        public int DayLogId { get; set; }

        public int MonthLogId { get; set; }
        public MonthLog MonthLog { get; set; }


        public DateTime Day { get; set; }

        public TimeSpan Arrive { get; set; }
        public TimeSpan Leave { get; set; }

        public TimeSpan InOffice { get; set; }
        public TimeSpan OutOfOffice { get; set; }

        public List<LogEntry> Entries { get; set; }
    }
}
