using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.Models
{
    public class MonthLog
    {
        public int MonthLogId { get; set; }

        public int UserId { get; set; }
        public OfficeUser User { get; set; }

        public TimeSpan AverageIn { get; set; }
        public TimeSpan AverageOut { get; set; }
    }
}
