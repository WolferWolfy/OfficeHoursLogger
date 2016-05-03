using System;

namespace OfficeHoursShared
{
    public class LogEntry
    {
        public int LogEntryId { get; set; }

        public int UserId { get; set; }
        public OfficeUser User { get; set; }

        public DateTime Time { get; set; }
        public ActionDirection Direction { get; set; }
        public string Name { get; set; }
    }
}
