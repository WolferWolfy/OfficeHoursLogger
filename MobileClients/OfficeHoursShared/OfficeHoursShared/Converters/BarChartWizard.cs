using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace OfficeHoursShared
{
	public class BarChartWizard
	{
		public BarChartWizard ()
		{
		}

		public static void Magic (RelativeLayout layout, List<ChartModel> chartModels)
		{
			layout.HorizontalOptions = LayoutOptions.FillAndExpand;
			layout.VerticalOptions = LayoutOptions.Fill;
			layout.Padding = 1;

			int count = chartModels.Count;
			double upperEmptySpace = 10;
			double maxHeight = layout.Height - upperEmptySpace;

			TimeSpan maxInOutTimeSpan = chartModels.Max (cm => cm.InTime + cm.OutTime);

			double MaxMinutes = maxInOutTimeSpan.TotalMinutes;
			double width = layout.Width;



			var barSpaces = CalculateBarWidthAndSpaces (layout.Width, count);
			double barWidth = barSpaces.Item1;
			double spaces = barSpaces.Item2;

			int position = 0;
			foreach (var item in chartModels) {

				double heightRatioIn = (item.InTime).TotalMinutes / MaxMinutes;
				double heightRatioOut = (item.OutTime).TotalMinutes / MaxMinutes;
				double xPos = 2 * spaces + position * (barWidth + spaces);

				BoxView boxOutTime = new BoxView ();
				boxOutTime.Color = Color.Red;
				boxOutTime.Margin =  new Thickness(1,1,1,0);

				layout.Children.Add (boxOutTime, 
					Constraint.RelativeToParent ((parent) => {
						return ( xPos);
					}),
					Constraint.Constant (upperEmptySpace + (1 - heightRatioOut - heightRatioIn) * (maxHeight) ),
					Constraint.RelativeToParent ((parent) => {
						return (barWidth);
					}),
					Constraint.RelativeToParent ((parent) => {
						return ( heightRatioOut * (maxHeight));
					})
				);

				BoxView boxInTime = new BoxView ();
				boxInTime.Color = Color.Green;
				boxInTime.Margin = new Thickness(1,0,1,1);

				layout.Children.Add (boxInTime, 
					Constraint.RelativeToParent ((parent) => {
					return ( xPos);
					}),
					Constraint.Constant (upperEmptySpace + (1 - heightRatioIn) * (maxHeight) ),
					Constraint.RelativeToParent ((parent) => {
						return (barWidth);
					}),
					Constraint.RelativeToParent ((parent) => {
						return ( heightRatioIn * maxHeight);
					})
				);

				Label dateLabel = new Label ();
				dateLabel.Margin = boxInTime.Margin;
				dateLabel.Text = String.Format("{0:yy/MM}", item.Date) ;
				dateLabel.FontSize= 10;
				dateLabel.Rotation =  -90;
				dateLabel.TextColor = Color.White;
				dateLabel.VerticalTextAlignment = TextAlignment.Center;
				dateLabel.HorizontalTextAlignment = TextAlignment.Center;
				//dateLabel.BackgroundColor = position % 2 == 0 ? Color.FromHex("#795D") : Color.Transparent;
				layout.Children.Add (dateLabel, 
					Constraint.RelativeToParent ((parent) => {
						return ( xPos - (heightRatioIn * maxHeight - barWidth)/2 );
					}),
					Constraint.Constant (upperEmptySpace + (1 - heightRatioIn) * (maxHeight)  + boxInTime.Height/2 - barWidth/2 ),
					Constraint.Constant(heightRatioIn * maxHeight),
					Constraint.Constant(barWidth)
				);

				position++;
			}

			double workTimeLine = 8 * 60 / MaxMinutes;
		
			BoxView line = new BoxView ();
			line.Color = Color.Black;
			//line.Margin =  new Thickness(1,1,1,0);

			layout.Children.Add (line, 
				Constraint.Constant(0),
				Constraint.Constant (upperEmptySpace + (1 - workTimeLine) * maxHeight ),
				Constraint.Constant(width),
				Constraint.Constant(1)
				);
		/*	layout.Children.Add (line, 
				Constraint.Constant(0),
				Constraint.Constant(10),
				Constraint.Constant(width),
				Constraint.Constant(1)
			);*/
		}

		private static Tuple<double,double> CalculateBarWidthAndSpaces(double width, int count) {

			double maxBarWidth = 44.0;

			double spaces = 0.0;
			double barWidth = maxBarWidth;

			double bars = count * maxBarWidth;

			if (bars > width) {
				barWidth = width / count;
			} else {
				double spacesToDistribute = width - bars;
				spaces = spacesToDistribute / (count + 3);
			}


			return new Tuple<double, double>(barWidth, spaces);
		}

	}


	public class ChartModel
	{
		public TimeSpan InTime { get; set; }

		public TimeSpan OutTime { get; set; }


		public DateTime Date { get; set; }

		public ChartModel ()
		{
			
		}

		public ChartModel (MonthViewModel monthVM)
		{
			Date = monthVM.Month.DateTime;
			InTime = monthVM.AverageIn;
			OutTime = monthVM.AverageOut;
		}
	}
}

