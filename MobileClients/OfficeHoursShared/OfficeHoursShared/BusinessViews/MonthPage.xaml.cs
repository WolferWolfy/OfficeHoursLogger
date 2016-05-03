using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace OfficeHoursShared
{
	public partial class MonthPage : ContentPage
	{
		public MonthPage ()
		{
			InitializeComponent ();
		}

		public MonthPage (DateTimeViewModel dateTimeVM)
		{
			InitializeComponent ();

			Title = dateTimeVM.DateTime.ToString("yyyy - MMMM");
			DataProvider dataProvider = new DataProvider ();
			MonthViewModel aMonth = dataProvider.GetMonths().Where(m => m.Month.Year == dateTimeVM.Year && m.Month.Month == dateTimeVM.Month).FirstOrDefault();
			MonthView.ItemsSource = aMonth.Days;
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

			DayViewModel selected = (DayViewModel) e.SelectedItem;

			Navigation.PushAsync(new DayPage(selected));
		}
	}
}

