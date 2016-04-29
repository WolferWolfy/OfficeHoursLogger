using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OfficeHoursShared
{
	public partial class DayPage : ContentPage
	{
		public DayPage ()
		{
			InitializeComponent ();

			DayView.ItemsSource = new List<string>(){ "08:05 - Enter", "11:30 - Exit", "11:55 - Enter", "17:10 - Exit" };
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			//((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

			Navigation.PushAsync(new EntryPage());
		}
	}
}

