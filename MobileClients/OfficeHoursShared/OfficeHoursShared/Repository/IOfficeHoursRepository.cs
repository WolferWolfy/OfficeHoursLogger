using System;
using System.Collections.Generic;

namespace OfficeHoursShared
{
	public interface IOfficeHoursRepository
	{
		void AddEntry(LogEntryViewModel logEntry);

		LogEntryViewModel FindEntryById(int id);

		List<MonthViewModel> FindAllMonth();

		void UpdateEntry(LogEntryViewModel logEntry);

		void DeleteEntryById(int id);
	}
}

