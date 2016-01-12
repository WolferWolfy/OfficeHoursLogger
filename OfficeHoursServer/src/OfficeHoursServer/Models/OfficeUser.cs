using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.Models
{
    public class OfficeUser
    {

        public int OfficeUserId { get; set; }

        public string Email { get; set; }

        public List<MonthLog> MonthLogs { get; set; }

        public OfficeUser(string email)
        {
            Email = email;
        }
    }
}
