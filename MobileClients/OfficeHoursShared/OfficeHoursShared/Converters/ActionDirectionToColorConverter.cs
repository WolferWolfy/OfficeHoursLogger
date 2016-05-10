using System;
using Xamarin.Forms;
using System.Globalization;
using OfficeHoursShared;

namespace Toolkit
{
	public class ActionDirectionToColorConverter : IValueConverter
	{
		public Color EntryColor {
			get;
			set;
		}

		public Color ExitColor {
			get;
			set;
		}
			
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			ActionDirection directionValue = (ActionDirection) value;
			
			return directionValue == ActionDirection.Entry ? Color.Green : Color.Red;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

