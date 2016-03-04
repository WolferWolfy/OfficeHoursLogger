using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHours
{
	public class MonthModel
	{
		// unique for a user.
		public int Id { get; set; }

		public DateTime Month { get; set; }
		public TimeSpan AverageIn { get; set; }
		public TimeSpan AverageOut { get; set; }

		public List<DayModel> Days { get; set; }

		public MonthModel ()
		{
		}
	}
}

