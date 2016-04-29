using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OfficeHoursShared
{
	public partial class MonthPage : ContentPage
	{
		public MonthPage ()
		{
			InitializeComponent ();
		}

		public MonthPage (string name)
		{
			InitializeComponent ();

			Title = name;
			MonthView .ItemsSource = new List<string>(){ "January 1", "January 2", "January 3" };
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			//((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.


			Navigation.PushAsync(new DayPage());
		}
	}
}

