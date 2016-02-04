﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using OfficeHoursServer.ViewModels;
using OfficeHoursServer.Models;
using AutoMapper;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeHoursServer.Controllers
{
    public class TestController :BaseController
    {
        [HttpGet]
        public object Ping()
        {
            return new
            {
                message = "Pong. You accessed an unprotected endpoint."
            };
        }

        [HttpGet]
        [Authorize(ActiveAuthenticationSchemes = "Bearer")]
        public object SecuredPing()
        {
            return new
            {
                message = "Pong. You accessed a protected endpoint.",
                claims = User.Claims.Select(c => new { c.Type, c.Value })
            };
        }

        // api/test/DayLog
        [HttpGet]
        public DayViewModel DayLog()
        {
            DateTime requestDate = new DateTime(2016, 1, 4, 0, 0, 0);

            var entryList = OfficeHoursContext.LogEntries
                .Include(le => le.User)
              //  .Where(le => le.User.Email.Equals(LoggedInUser.Email))
                .Where(le => le.Time.Date == requestDate.Date)
                .OrderBy(le => le.Time)
                .ToList();

            DayViewModel dayVM = new DayViewModel();
            dayVM.LogEntries = Mapper.Map<List<LogEntryViewModel>>(entryList);

            return dayVM;
        }
    }
}
