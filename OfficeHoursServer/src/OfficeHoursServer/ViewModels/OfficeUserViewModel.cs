using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeHoursServer.ViewModels
{
    public class OfficeUserViewModel
    {
        public string Email { get; set; }

        public List<MonthViewModel> Months { get; set; }


    }
}
