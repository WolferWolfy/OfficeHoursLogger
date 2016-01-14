using OfficeHoursServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.ViewModels
{
    public class LogEntryViewModel
    {
        public int LogEntryId { get; set; }
        public DateTimeViewModel Time { get; set; }
        public ActionDirection Direction { get; set; }
        public string Name { get; set; }

    }
}
