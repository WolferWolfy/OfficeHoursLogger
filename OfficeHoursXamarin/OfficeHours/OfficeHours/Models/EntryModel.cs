using System;

namespace OfficeHours
{
	public class EntryModel
	{
		public int LogEntryId { get; set; }
		public DateTime Time { get; set; }
		public ActionDirection Direction { get; set; }
		public string Name { get; set; }


		public EntryModel ()
		{
		}
	}
}

