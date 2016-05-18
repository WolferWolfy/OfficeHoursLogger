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

		double width;
		double height;

		public SummaryPage ()
		{
			InitializeComponent ();

			Title = "Summary";

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

		void BarCharting ()
		{
			ChartModel cm1 = new ChartModel () {
				InTime = new TimeSpan (7, 50, 0),
				OutTime = new TimeSpan (0, 30, 0),
				Date = new DateTime (2016, 01, 01)
			};
			ChartModel cm2 = new ChartModel () {
				InTime = new TimeSpan (7, 25, 0),
				OutTime = new TimeSpan (0, 35, 0),
				Date = new DateTime (2016, 02, 07)
			};
			var months = OfficeUserVM.Months;
			if (months == null) {
				return;
			}

			List<ChartModel> cms = months.ConvertToChartModel<MonthViewModel> ();
			var mocks = new List<ChartModel> () {
				cm1,
				cm2,
				cm2,
				cm1,
				cm2,
				cm1,
				cm2,
				cm1,
				cm1
			};
			cms.AddRange (mocks);
			barChart.Children.Clear ();
			BarChartWizard.Magic (barChart, cms);
		}

		protected override void OnAppearing ()
		{
			OfficeUserVM.Months = OfficeHoursRepository.FindAllMonth ();

			MonthsListView.ItemsSource = OfficeUserVM.Months;

			BarCharting ();





		}

		protected override void OnSizeAllocated (double width, double height)
		{
			base.OnSizeAllocated (width, height);
			if (width != this.width || height != this.height) {
				this.width = width;
				this.height = height;

				BarCharting ();
			}
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

