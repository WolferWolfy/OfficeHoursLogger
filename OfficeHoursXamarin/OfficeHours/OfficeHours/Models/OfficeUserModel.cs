using System;
using System.Collections.Generic;

namespace OfficeHours
{
	public class OfficeUserModel
	{
		public string Email { get; set; }

		public List<MonthModel> Months { get; set; }

		public OfficeUserModel ()
		{
		}
	}
}

