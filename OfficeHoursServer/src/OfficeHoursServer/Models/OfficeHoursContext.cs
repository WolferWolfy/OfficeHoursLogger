using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace OfficeHoursServer.Models
{
    public class OfficeHoursContext : DbContext
    {
        public DbSet<OfficeUser> Users { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
    }
}
