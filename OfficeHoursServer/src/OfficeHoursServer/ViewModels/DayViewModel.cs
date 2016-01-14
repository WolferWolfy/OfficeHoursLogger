
using OfficeHoursServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.ViewModels
{
    public class DayViewModel
    {
        public DateTimeViewModel Day { get { return Arrive; } }
        public DateTimeViewModel Arrive { get { return LogEntries.FirstOrDefault().Time; } }
        public DateTimeViewModel Leave { get { return LogEntries.LastOrDefault().Time; } }
        public TimeSpan InOffice { get {return CalculateInOfficeTime() ;} }
        public TimeSpan OutOfOffice { get { return CalculateOutOfOffice(); } }

        public List<LogEntryViewModel> LogEntries { get; set; }


        private TimeSpan CalculateInOfficeTime()
        {
            TimeSpan fullIn = Leave.Subtract(Arrive);

            return fullIn.Subtract(OutOfOffice);
        }

        private TimeSpan CalculateOutOfOffice()
        {
            TimeSpan breakTime = new TimeSpan();

            DateTimeViewModel lastExitTime = null;// = new DateTime();

            // ordering may not be needed here.
            foreach (LogEntryViewModel logEntryVM in LogEntries.OrderBy(le => le.Time))
            {
                if (logEntryVM.Direction == ActionDirection.Exit && lastExitTime == null)
                {
                    lastExitTime = logEntryVM.Time;
                    continue;
                }

                if (logEntryVM.Direction == ActionDirection.Entry && lastExitTime != null)
                {
                    breakTime = breakTime.Add(logEntryVM.Time.Subtract(lastExitTime));
                    lastExitTime = null;
                }
            }

            return breakTime;
        }
    }
}
