using System;
using System.Collections.Generic;

namespace OfficeHours
{
	public class DayModel
	{
		public DateTime Day { get; set; }
		public DateTime Arrive { get; set; }
		public DateTime Leave { get; set; }
		public TimeSpan InOffice { get; set; }
		public TimeSpan OutOfOffice { get; set; }

		public List<EntryModel> Entries { get; set; }

		public DayModel ()
		{
		}
	}
}

