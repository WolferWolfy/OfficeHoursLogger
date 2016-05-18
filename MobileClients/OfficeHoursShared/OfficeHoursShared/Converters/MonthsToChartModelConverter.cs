using System;
using System.Collections.Generic;

namespace OfficeHoursShared
{
	public static class MonthListToChartExtension 
	{
		public static List<ChartModel> ConvertToChartModel<MonthViewModel>(this List<OfficeHoursShared.MonthViewModel> list)
		{
			List<ChartModel> chartModels = new List<ChartModel>(list.Count);

			foreach (var month in list) {
				ChartModel model = new ChartModel (month);
				chartModels.Add (model); 
			}
			return chartModels;
		}
	}

}

