using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace OfficeHoursShared
{
	public partial class MonthPage : ContentPage
	{

	    IOfficeHoursRepository OfficeHoursRepository;
		MonthViewModel month;

		DateTimeViewModel dateTime;

		public MonthPage (DateTimeViewModel dateTimeVM)
		{
			InitializeComponent ();
			OfficeHoursRepository = RepositoryManager.Repository;
			Title = dateTimeVM.DateTime.ToString("yyyy - MMMM");
			dateTime = dateTimeVM;
		}

		protected override void OnAppearing ()
		{
			month = OfficeHoursRepository.FindAllMonth().Where(m => m.Month.Year == dateTime.Year && m.Month.Month == dateTime.Month).FirstOrDefault();
			MonthView.ItemsSource = month.Days;
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

