﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.ViewModels
{
    public class MonthViewModel
    {
        public int Month { get { return Days.FirstOrDefault().Day.Month; } }
        public TimeSpan AverageIn { get { return CalculateAverageIn(); } }
        public TimeSpan AverageOut { get { return CalculateAverageOut(); } }

        public List<DayViewModel> Days { get; set; }

        private TimeSpan CalculateAverageIn()
        {
            TimeSpan fullIn = new TimeSpan();

            Days.ForEach(d => fullIn.Add(d.InOffice));
            double averageSeconds = fullIn.TotalSeconds / Days.Count;

            return TimeSpan.FromSeconds(averageSeconds);
        }

        private TimeSpan CalculateAverageOut()
        {
            TimeSpan fullOut = new TimeSpan();

            Days.ForEach(d => fullOut.Add(d.OutOfOffice));
            double averageSeconds = fullOut.TotalSeconds / Days.Count;

            return TimeSpan.FromSeconds(averageSeconds);
        }
    }
}
