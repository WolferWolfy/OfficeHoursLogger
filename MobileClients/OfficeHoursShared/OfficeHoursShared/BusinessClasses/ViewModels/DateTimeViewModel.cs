using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHoursShared
{
    public class DateTimeViewModel : IComparable
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

		public DateTime DateTime {
			get {
				return ToDateTime ();
			}
		}

		public DateTimeViewModel(){}

		public DateTimeViewModel (int year, int month, int day, int hour, int minute, int second)
		{
			Year = year;
			Month = month;
			Day = day;
			Hour = hour;
			Minute = minute;
			Second = second;
		}

        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }

        public TimeSpan Subtract(DateTimeViewModel dateTimeVM)
        {
            return this.ToDateTime().Subtract(dateTimeVM.ToDateTime());
        }

        public int CompareTo(object obj)
        {
            return this.ToDateTime().CompareTo(((DateTimeViewModel)obj).ToDateTime());
        }
    }
}
