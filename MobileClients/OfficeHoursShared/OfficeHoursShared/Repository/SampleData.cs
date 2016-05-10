using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHoursShared
{
	public class SampleData
	{
		private static SampleData instance;

		private SampleData() {
			CreateUser1Entries ();
			CreateUser2Entries();
		}

		public static SampleData Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new SampleData();
				}
				return instance;
			}
		}

		public List<LogEntryViewModel> User1Entries { get; set; }

		public List<LogEntryViewModel> User2Entries { get; set;}
			
		public void CreateUser1Entries() {
			
			User1Entries = new List<LogEntryViewModel>() {
				new LogEntryViewModel()
				{
					LogEntryId = 1,
					Time = new DateTimeViewModel(2016, 1, 5, 9, 10, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 2,
					Time = new DateTimeViewModel(2016, 1, 5, 11, 30, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 3,
					Time = new DateTimeViewModel(2016, 1, 5, 11, 55, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 4,
					Time = new DateTimeViewModel(2016, 1, 5, 17, 50, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 5,
					Time = new DateTimeViewModel(2016, 2, 1, 9, 00, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 6,
					Time = new DateTimeViewModel(2016, 2, 1, 11, 30, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 7,
					Time = new DateTimeViewModel(2016, 2, 1, 12, 05, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 8,
					Time = new DateTimeViewModel(2016, 2, 1, 17, 45, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 9,
					Time = new DateTimeViewModel(2016, 2, 2, 8, 30, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 10,
					Time = new DateTimeViewModel(2016, 2, 2, 11, 25, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 11,
					Time = new DateTimeViewModel(2016, 2, 2, 12, 10, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 12,
					Time = new DateTimeViewModel(2016, 2, 2, 14, 0, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 13,
					Time = new DateTimeViewModel(2016, 2, 2, 14, 15, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 14,
					Time = new DateTimeViewModel(2016, 2, 2, 18, 10, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				}
			};
		}

		public void CreateUser2Entries() {

			User2Entries = new List<LogEntryViewModel>() {
				new LogEntryViewModel()
				{
					LogEntryId = 101,
					Time = new DateTimeViewModel(2016, 2, 1, 10, 10, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 102,
					Time = new DateTimeViewModel(2016, 2, 1, 11, 20, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 103,
					Time = new DateTimeViewModel(2016, 2, 1, 12, 15, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 104,
					Time = new DateTimeViewModel(2016, 2, 1, 18, 15, 0),
					Direction = ActionDirection.Exit,
					Name = "Depart"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 105,
					Time = new DateTimeViewModel(2016, 2, 2, 8, 50, 0),
					Direction = ActionDirection.Entry,
					Name = "Arrive"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 106,
					Time = new DateTimeViewModel(2016, 2, 2, 11, 35, 0),
					Direction = ActionDirection.Exit,
					Name = "Break start"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 107,
					Time = new DateTimeViewModel(2016, 2, 2, 12, 30, 0),
					Direction = ActionDirection.Entry,
					Name = "Break end"
				},
				new LogEntryViewModel()
				{
					LogEntryId = 108,
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

				theDayVM.LogEntries = theDayVM.LogEntries.OrderBy (le => le.Time).ToList ();
				//theDayVM.LogEntries = theDayVM.LogEntries.OrderBy(le => le.Time);
				monthVM.Days.Add(theDayVM);
			}

			return monthVM;
		}


	}
}


