using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OfficeHoursShared
{
	public partial class SummaryPage : ContentPage
	{
		IOfficeHoursRepository OfficeHoursRepository;
		OfficeUserViewModel OfficeUserVM;

		public SummaryPage ()
		{
			InitializeComponent ();

			Title = "Summary";
			BarChart.Source = PlatformImageResource ("temp_bar_chart.png");

			// if moved to OfficeHoursShared.iOS/Resources:
			// BarChart.Source = ImageSource.FromFile("temp_bar_chart.png");

			RepositoryManager.CreateRepository (RepositoryType.Mock, "user1");

			OfficeHoursRepository = RepositoryManager.Repository;

			OfficeUserVM = new OfficeUserViewModel();
		}


		private string _baseResource;
		public string BaseResource
		{
			get
			{
				return _baseResource ?? (_baseResource = Assembly.GetExecutingAssembly ().FullName.Split (',').FirstOrDefault ());
			}
		}

		protected override void OnAppearing ()
		{
			OfficeUserVM.Months = OfficeHoursRepository.FindAllMonth ();

			MonthsListView.ItemsSource = OfficeUserVM.Months;
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

			MonthViewModel selected = (MonthViewModel) e.SelectedItem;

			Navigation.PushAsync(new MonthPage(selected.Month));
		}

		private ImageSource PlatformImageResource(string resource)
		{
			var br = BaseResource;
			return ImageSource.FromResource(BaseResource + "." + resource);
		}

		private void NewEntryScenario(object sender, EventArgs eventArgs)
		{
			DateTime now = DateTime.Now; 
			LogEntryViewModel newEntry = new LogEntryViewModel () {
				Time = new DateTimeViewModel (now.Year, now.Month, now.Day, now.Hour, now.Minute, 0)
			};
			Navigation.PushAsync (new EntryPage (newEntry, true));
		}

	}
		
}

