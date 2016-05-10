using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHoursShared
{
    public class LogEntryViewModel
    {
        public int LogEntryId { get; set; }
        public DateTimeViewModel Time { get; set; }
        public ActionDirection Direction { get; set; }
        public string Name { get; set; }

		public LogEntryViewModel ()
		{
			Time = new DateTimeViewModel ();
		}
    }
}
