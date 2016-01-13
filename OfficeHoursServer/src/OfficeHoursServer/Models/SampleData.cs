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



            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();
            


                if (!context.LogEntries.Any())
                {
                var office1User = new OfficeUser("office1@o.o");
                    context.Users.Add(office1User);

                var office2User = new OfficeUser("office2@o.o");
                    context.Users.Add(office2User);


                context.LogEntries.AddRange(
                        new LogEntry()
                        {
                            User = office1User,
                            Time = new DateTime(2016, 1, 4, 8, 20, 0),
                            Direction = ActionDirection.Entry,
                            Name = "Arrive"
                        },
                       new LogEntry()
                       {
                           User = office1User,
                           Time = new DateTime(2016, 1, 4, 12, 00, 0),
                           Direction = ActionDirection.Exit,
                           Name = "Break start"
                       },
                       new LogEntry()
                       {
                           User = office1User,
                           Time = new DateTime(2016, 1, 4, 13, 55, 0),
                           Direction = ActionDirection.Entry,
                           Name = "Break end"
                       },
                       new LogEntry()
                       {
                           User = office1User,
                           Time = new DateTime(2016, 1, 4, 18, 10, 0),
                           Direction = ActionDirection.Exit,
                           Name = "Depart"
                       }
                   );


                    context.LogEntries.AddRange(
                       new LogEntry()
                       {
                           User = office1User,
                           Time = new DateTime(2016, 1, 5, 9, 10, 0),
                           Direction = ActionDirection.Entry,
                           Name = "Arrive"
                       },
                      new LogEntry()
                      {
                          User = office1User,
                          Time = new DateTime(2016, 1, 5, 11, 30, 0),
                          Direction = ActionDirection.Exit,
                          Name = "Break start"
                      },
                      new LogEntry()
                      {
                          User = office1User,
                          Time = new DateTime(2016, 1, 5, 11, 55, 0),
                          Direction = ActionDirection.Entry,
                          Name = "Break end"
                      },
                      new LogEntry()
                      {
                          User = office1User,
                          Time = new DateTime(2016, 1, 5, 17, 50, 0),
                          Direction = ActionDirection.Exit,
                          Name = "Depart"
                      }
                  );

                    context.SaveChanges();
                }
            }
    }
}
