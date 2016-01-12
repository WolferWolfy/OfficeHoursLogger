using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;


namespace OfficeHoursServer.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<OfficeHoursContext>();

         //  if(serviceProvider.GetService<IRelationalDatabaseCreator>().Exists())

            if (context.Database.EnsureCreated())
            {
                if (!context.LogEntries.Any())
                {
                    var office1User = context.Users.Add(new OfficeUser("office1@o.o")).Entity;

                    var office2User = context.Users.Add(new OfficeUser("office2@o.o")).Entity;

                    var month1U1 = context.MonthLogs.Add(new MonthLog()
                    {
                        User = office1User
                    }).Entity;

                    var month1U2 = context.MonthLogs.Add(new MonthLog()
                    {
                        User = office2User
                    }).Entity;

                    var day4M1U1 = context.DayLogs.Add(new DayLog()
                    {
                        MonthLog = month1U1,
                        Day = new DateTime(2016, 1, 4)
                    }).Entity;


                    var day5M1U1 = context.DayLogs.Add(new DayLog()
                    {
                        MonthLog = month1U1,
                        Day = new DateTime(2016, 1, 5)
                    }).Entity;

                    context.LogEntries.AddRange(
                        new LogEntry()
                        {
                            DayLog = day4M1U1,
                            Time = new TimeSpan(8, 20, 0),
                            Direction = ActionDirection.Entry,
                            Name = "Arrive"
                        },
                       new LogEntry()
                       {
                           DayLog = day4M1U1,
                           Time = new TimeSpan(12, 00, 0),
                           Direction = ActionDirection.Exit,
                           Name = "Break start"
                       },
                       new LogEntry()
                       {
                           DayLog = day4M1U1,
                           Time = new TimeSpan(13, 55, 0),
                           Direction = ActionDirection.Entry,
                           Name = "Break end"
                       },
                       new LogEntry()
                       {
                           DayLog = day4M1U1,
                           Time = new TimeSpan(18, 10, 0),
                           Direction = ActionDirection.Exit,
                           Name = "Depart"
                       }
                   );


                    context.LogEntries.AddRange(
                       new LogEntry()
                       {
                           DayLog = day5M1U1,
                           Time = new TimeSpan(9, 10, 0),
                           Direction = ActionDirection.Entry,
                           Name = "Arrive"
                       },
                      new LogEntry()
                      {
                          DayLog = day5M1U1,
                          Time = new TimeSpan(11, 30, 0),
                          Direction = ActionDirection.Exit,
                          Name = "Break start"
                      },
                      new LogEntry()
                      {
                          DayLog = day5M1U1,
                          Time = new TimeSpan(11, 55, 0),
                          Direction = ActionDirection.Entry,
                          Name = "Break end"
                      },
                      new LogEntry()
                      {
                          DayLog = day5M1U1,
                          Time = new TimeSpan(17, 50, 0),
                          Direction = ActionDirection.Exit,
                          Name = "Depart"
                      }
                  );

                    context.SaveChanges();
                }
            }
        }
    }
}
