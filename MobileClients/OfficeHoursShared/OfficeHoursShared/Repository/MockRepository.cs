using System;
using System.Linq;
using System.Collections.Generic;

namespace OfficeHoursShared
{
	public class MockRepository : IOfficeHoursRepository
	{
		public string UserName {
			get;
			set;
		}
		private static SampleData sampleData;
		public static MockRepository instance;

		private MockRepository() {
			throw new Exception("who called this constructor?!?");
		}

		public static MockRepository Instance
		{
			get 
			{
				if (instance == null)
				{
					throw new Exception("Object not created");
				}
				return instance;
			}
		}
		private MockRepository(string userName) {
			UserName = userName;
			sampleData = SampleData.Instance;
		}

		public static void Create(string userName)
		{
			if (instance != null)
			{
				throw new Exception("Object already created");
			}
			instance = new MockRepository(userName); 

		}

		#region IOfficeHoursRepository implementation

		public void AddEntry (LogEntryViewModel logEntry)
		{
			int lastId = sampleData.User1Entries.Max (e => e.LogEntryId);
			if (logEntry.LogEntryId == 0) {
				logEntry.LogEntryId = lastId + 1;
			}

			sampleData.User1Entries.Add (logEntry);

			return;
		}

		public LogEntryViewModel FindEntryById (int id)
		{
			// Find: first occurence.
			var result = sampleData.User1Entries.Find (e => e.LogEntryId == id);

			return result;
		}

		public List<MonthViewModel> FindAllMonth ()
		{
			return SampleData.EntriesToMonths(sampleData.User1Entries);
		}

		public void UpdateEntry (LogEntryViewModel logEntry)
		{
			var entry = sampleData.User1Entries.Find (le => le.LogEntryId == logEntry.LogEntryId);

			entry.Name = logEntry.Name;
			entry.Direction = logEntry.Direction;
			entry.Time = logEntry.Time;

			return;
		}

		public void DeleteEntryById (int id)
		{
			sampleData.User1Entries.Remove (FindEntryById(id));

			return;
		}

		#endregion
	}
}

