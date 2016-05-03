using System.Collections.Generic;

namespace OfficeHoursShared
{
    public class OfficeUser
    {

        public int OfficeUserId { get; set; }
        public string Email { get; set; }

        public List<LogEntry> Entries { get; set; }

        public OfficeUser()
        {
            Entries = new List<LogEntry>(); 
        }

        public OfficeUser(string email)
        {
            Email = email;
            Entries = new List<LogEntry>();
        }
    }
}
