﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OfficeHoursServer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using OfficeHoursServer.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeHoursServer.Controllers
{

    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class LogEntryController : BaseController
    {
        // api/logentry/DayLog
        [HttpPost]
        public DayViewModel DayLog([FromBody] DateTimeViewModel date)
        {
            if (date.Day == 0)
            {
                date.Day = 1;
            }
            DateTime requestDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

            var useruseruser = LoggedInUser;

            if (useruseruser == null)
            {
                var a = "nulllll";
                useruseruser = OfficeHoursContext.Users.Where(u => u.Email.Equals("office1@o.o")).FirstOrDefault();
            }
            var entryList = OfficeHoursContext.LogEntries
                .Include(le => le.User)
                .Where(le =>le.User.Email.Equals(useruseruser.Email))
                .Where(le => le.Time.Date == requestDate.Date)
                .OrderBy(le => le.Time)
                .ToList();

            DayViewModel dayVM = new DayViewModel();
            dayVM.LogEntries = Mapper.Map<List<LogEntryViewModel>>(entryList);

            return dayVM;
        }

        // api/logentry/MonthLog
        [HttpPost]
        public MonthViewModel MonthLog([FromBody] DateTimeViewModel date)
        {
            if (date.Day == 0)
            {
                date.Day = 1;
            }
            DateTime requestDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

            var useruseruser = LoggedInUser;

            if (useruseruser == null)
            {
                var a = "nulllll";
                useruseruser = OfficeHoursContext.Users.Where(u => u.Email.Equals("office1@o.o")).FirstOrDefault();
            }

            var groupedByDayEntries = OfficeHoursContext.LogEntries
                .Include(le => le.User)
                .Where(le => le.User.OfficeUserId == useruseruser.OfficeUserId)
                .Where(le => le.Time.Year == requestDate.Year && le.Time.Month == requestDate.Month)
                .OrderBy(le => le.Time)
                .GroupBy(le => le.Time.Day);


            return SortIntoMonthByDays(groupedByDayEntries);
        }

        // api/logentry/CompleteLog
        [HttpPost]
        public List<MonthViewModel> CompleteLog()
        {
            List<MonthViewModel> everyMonth = new List<MonthViewModel>();

            var useruseruser = LoggedInUser;

            if (useruseruser == null)
            {
                var a = "nulllll";
                
                useruseruser = OfficeHoursContext.Users.Where(u => u.Email.Equals("office1@o.o")).FirstOrDefault();
        }

            var entriesList = OfficeHoursContext.LogEntries
                .Include(le => le.User)
                .Where(le => le.UserId == useruseruser.OfficeUserId)
                .OrderBy(le => le.Time);      

            var byYear = entriesList.GroupBy(el => el.Time.Year).ToList();

            foreach (var groupByAYear in byYear)
            {
                var logEntriesInAYear = new List<LogEntry>();

                foreach (LogEntry logEntry in groupByAYear)
                {
                    logEntriesInAYear.Add(logEntry);
                }

                var byMonthInAYear = logEntriesInAYear.GroupBy(el => el.Time.Month).ToList();
                foreach (var groupByAMonth in byMonthInAYear)
                {
                    var logEntriesInAMonth = new List<LogEntry>();

                    foreach (LogEntry logEntry in groupByAMonth)
                    {
                        logEntriesInAMonth.Add(logEntry);
                    }
                    var byDayInAMonthInAYear = logEntriesInAMonth.GroupBy(el => el.Time.Day);

                    everyMonth.Add(SortIntoMonthByDays(byDayInAMonthInAYear));
                }
            }

            return everyMonth;
        }

        // api/logentry/EntryLog
        [HttpPost]
        public LogEntryViewModel EntryLog([FromBody] int id)
        {
            var useruseruser = LoggedInUser;

            if (useruseruser == null)
            {
                var a = "nulllll";
                useruseruser = OfficeHoursContext.Users.Where(u => u.Email.Equals("office1@o.o")).FirstOrDefault();
            }

            var entry = OfficeHoursContext.LogEntries
                .Include(le => le.User)
                .Where(le => le.User.Email.Equals(useruseruser.Email))
                .Where(le => le.LogEntryId == id)
                .FirstOrDefault();

            return Mapper.Map<LogEntryViewModel>(entry);
        }

        // api/logentry/AddLogEntry
        [HttpPost]
        public bool AddLogEntry([FromBody] LogEntryViewModel logEntryVM)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            LogEntry newEntry = Mapper.Map<LogEntry>(logEntryVM);

            newEntry.User = LoggedInUser;

            OfficeHoursContext.LogEntries.Add(newEntry);

            return OfficeHoursContext.SaveChanges() > 0;
        }


        // api/logentry/UpdateLogEntry
        [HttpPost]
        public bool UpdateLogEntry([FromBody] LogEntryViewModel logEntryVM)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            LogEntry updated = Mapper.Map<LogEntry>(logEntryVM);

            LogEntry old = OfficeHoursContext.LogEntries
                .Where(le => le.LogEntryId == updated.LogEntryId)
                .Where(le => le.UserId == LoggedInUser.OfficeUserId)
                .FirstOrDefault();

            if (old != null)
            {
                old.Name = updated.Name;
                old.Time = updated.Time;
                old.Direction = updated.Direction;
            }

            return OfficeHoursContext.SaveChanges() > 0;
        }

        // api/logentry/DeleteLogEntry
        [HttpPost]
        public bool DeleteLogEntry(int logEntryId)
        {
            LogEntry toBeDeleted = OfficeHoursContext.LogEntries
                .Where(le => le.LogEntryId == logEntryId)
                .Where(le => le.UserId == LoggedInUser.OfficeUserId)
                .FirstOrDefault();

            if (toBeDeleted != null)
            {
                OfficeHoursContext.LogEntries.Remove(toBeDeleted);

                return OfficeHoursContext.SaveChanges() > 0;
            }

            return false;
        }


        private MonthViewModel SortIntoMonthByDays(IEnumerable<IGrouping<int, LogEntry>> groupedByDayEntries)
        {
            MonthViewModel monthVM = new MonthViewModel();
            monthVM.Days = new List<DayViewModel>();

            foreach (var group in groupedByDayEntries)
            {

                DayViewModel theDayVM = new DayViewModel();
                theDayVM.LogEntries = new List<LogEntryViewModel>();

                int day = group.Key;
                foreach (LogEntry logEntry in group)
                {
                    theDayVM.LogEntries.Add(Mapper.Map<LogEntryViewModel>(logEntry));
                }

              //  theDayVM.LogEntries = theDayVM.LogEntries.OrderBy(le => le.Time);
                monthVM.Days.Add(theDayVM);
            }

            return monthVM;
        }
    }
}
