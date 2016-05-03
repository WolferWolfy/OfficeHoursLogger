using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHoursShared
{
	public class SampleData
	{
		public SampleData ()
		{
		}

		public static List<LogEntryViewModel> User1Entries() {
			
			return new List<LogEntryViewModel>() {
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 1, 5, 9, 10, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 1, 5, 11, 30, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 1, 5, 11, 55, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 1, 5, 17, 50, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 9, 00, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 11, 30, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 12, 05, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 17, 45, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 8, 30, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 11, 25, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 12, 10, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 14, 0, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 14, 15, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 18, 10, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				}
			};
		}

		public static List<LogEntryViewModel> User2Entries() {

			return new List<LogEntryViewModel>() {
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 10, 10, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 11, 20, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 12, 15, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 1, 18, 15, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 8, 50, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 11, 35, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 12, 30, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					Time = new DateTimeViewModel(2016, 2, 2, 18, 40, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				}
			};
		}


		public static List<MonthViewModel> EntriesToMonths(List<LogEntryViewModel> entriesList) {
			
			List<MonthViewModel> everyMonth = new List<MonthViewModel> ();

			var byYear = entriesList.GroupBy (el => el.Time.Year).ToList ();

			foreach (var groupByAYear in byYear) {
				var logEntriesInAYear = new List<LogEntryViewModel> ();

				foreach (LogEntryViewModel logEntry in groupByAYear) {
					logEntriesInAYear.Add (logEntry);
				}

				var byMonthInAYear = logEntriesInAYear.GroupBy (el => el.Time.Month).ToList ();
				foreach (var groupByAMonth in byMonthInAYear) {
					var logEntriesInAMonth = new List<LogEntryViewModel> ();

					foreach (LogEntryViewModel logEntry in groupByAMonth) {
						logEntriesInAMonth.Add (logEntry);
					}
					var byDayInAMonthInAYear = logEntriesInAMonth.GroupBy (el => el.Time.Day);

					everyMonth.Add (SortIntoMonthByDays (byDayInAMonthInAYear));
				}
			}

			return everyMonth;
		}

		private static MonthViewModel SortIntoMonthByDays(IEnumerable<IGrouping<int, LogEntryViewModel>> groupedByDayEntries)
		{
			MonthViewModel monthVM = new MonthViewModel();
			monthVM.Days = new List<DayViewModel>();

			foreach (var group in groupedByDayEntries)
			{

				DayViewModel theDayVM = new DayViewModel();
				theDayVM.LogEntries = new List<LogEntryViewModel>();

				int day = group.Key;
				foreach (LogEntryViewModel logEntry in group)
				{
					theDayVM.LogEntries.Add(logEntry);
				}

				//  theDayVM.LogEntries = theDayVM.LogEntries.OrderBy(le => le.Time);
				monthVM.Days.Add(theDayVM);
			}

			return monthVM;
		}


	}
}


