using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OfficeHoursShared
{
	public partial class DayPage : ContentPage
	{
		IOfficeHoursRepository OfficeHoursRepository;
		DayViewModel day;

		public DayPage (DayViewModel dayVM)
		{
			InitializeComponent ();

			Title = dayVM.Day.DateTime.ToString("yyyy/MM/dd");
		//	DayView.ItemsSource = dayVM.LogEntries ;
			day = dayVM;
			//update on view appear. or binding for propertychanged?

			OfficeHoursRepository = RepositoryManager.Repository;
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

			Navigation.PushAsync(new EntryPage((LogEntryViewModel)e.SelectedItem));
		}

		protected override void OnAppearing ()
		{
			var month = OfficeHoursRepository.FindAllMonth ().Where (m => m.Month.Year == day.Day.Year && m.Month.Month == day.Day.Month).FirstOrDefault();
			var selectedDay = month.Days.Where (d => d.Day.Day == day.Day.Day).FirstOrDefault();

			DayView.ItemsSource = selectedDay.LogEntries;
		}
	}
}

