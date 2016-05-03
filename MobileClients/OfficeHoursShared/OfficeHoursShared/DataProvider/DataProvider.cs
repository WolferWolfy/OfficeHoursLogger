using System;
using System.Collections.Generic;

namespace OfficeHoursShared
{
	public class DataProvider
	{
		public string UserEmail { get; set; }

		public DataProvider ()
		{
		}


		public List<MonthViewModel> GetMonths() {

			List<LogEntryViewModel> entries = SampleData.User1Entries ();
			return SampleData.EntriesToMonths(entries);
		}
	}
}

