using AutoMapper;
using OfficeHoursServer.Models;
using OfficeHoursServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.Settings
{
    public static class AutoMapperConfig
    {

        internal static void ConfigureAutomapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<DateTime, DateTimeViewModel>();

                config.CreateMap<LogEntry, LogEntryViewModel>().ReverseMap();
            });
        }
    }
}
