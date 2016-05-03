using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHoursShared
{
    public class MonthViewModel
    {
        // unique for a user.
        public int Id { get { return Month.Year * 100 + Month.Month; } }

        public DateTimeViewModel Month { get { return Days.FirstOrDefault().Day; } }
        public TimeSpan AverageIn { get { return CalculateAverageIn(); } }
        public TimeSpan AverageOut { get { return CalculateAverageOut(); } }

        public List<DayViewModel> Days { get; set; }

        private TimeSpan CalculateAverageIn()
        {
            TimeSpan fullIn = new TimeSpan();

            Days.ForEach(d => fullIn = fullIn.Add(d.InOffice));
            double averageSeconds = fullIn.TotalSeconds / Days.Count;

            return TimeSpan.FromSeconds(averageSeconds);
        }

        private TimeSpan CalculateAverageOut()
        {
            TimeSpan fullOut = new TimeSpan();

            Days.ForEach(d => fullOut = fullOut.Add(d.OutOfOffice));
            double averageSeconds = fullOut.TotalSeconds / Days.Count;

            return TimeSpan.FromSeconds(averageSeconds);
        }
    }
}
