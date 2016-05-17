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

		double width;
		double height;

		public DayPage (DayViewModel dayVM)
		{
			
			day = dayVM;


			InitializeComponent ();

			outerStack.BindingContext = this;

			Title = dayVM.Day.DateTime.ToString("yyyy/MM/dd");
		//	DayView.ItemsSource = dayVM.LogEntries ;
			//day = dayVM;
			//update on view appear. or binding for propertychanged?

			OfficeHoursRepository = RepositoryManager.Repository;

			ToolbarItems.Add(new ToolbarItem {
				Text = "Add Entry", 
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => AddNewEntry())
			});
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

			Navigation.PushAsync(new EntryPage((LogEntryViewModel)e.SelectedItem, false));
		}

		protected override void OnAppearing ()
		{
			var month = OfficeHoursRepository.FindAllMonth ().Where (m => m.Month.Year == day.Day.Year && m.Month.Month == day.Day.Month).FirstOrDefault();
			var selectedDay = month.Days.Where (d => d.Day.Day == day.Day.Day).FirstOrDefault();

			day = selectedDay;
			DayView.ItemsSource = day.LogEntries;

			UpdateSummaryLabels ();
		}
			
		protected override void OnSizeAllocated (double width, double height)
		{
			base.OnSizeAllocated (width, height);
			if (width != this.width || height != this.height) {
				this.width = width;
				this.height = height;
				if (width > height) {
					outerStack.Orientation = StackOrientation.Horizontal;
				} else {
					outerStack.Orientation = StackOrientation.Vertical;
				}
			}
		}

		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public async void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			LogEntryViewModel selectedEntry = mi.CommandParameter as LogEntryViewModel;

			var confirmDelete = await DisplayAlert (selectedEntry.Name, "Would you like to delete this entry?", "Yes", "No");
			if (confirmDelete) {
				OfficeHoursRepository.DeleteEntryById (selectedEntry.LogEntryId);
				//day.LogEntries.Remove (selectedEntry);
				//DayView.ItemsSource = day.LogEntries;
				OnAppearing ();
			}
		}

		private void UpdateSummaryLabels() {
			ArrivalLabel.Text = String.Format ("{0:HH:mm:ss}", day.Arrive.DateTime);
			LeaveLabel.Text = String.Format ("{0:HH:mm:ss}", day.Leave.DateTime);
			InOfficeLabel.Text = String.Format ("{0}", day.InOffice);
			OutOfOfficeLabel.Text = String.Format ("{0}", day.OutOfOffice);
		}

		public void AddNewEntry() {
			LogEntryViewModel newEntry = new LogEntryViewModel () {
				Time = new DateTimeViewModel() {
					Year = day.Day.Year,
					Month = day.Day.Month,
					Day = day.Day.Day
				}
			};
			Navigation.PushAsync(new EntryPage(newEntry, true));
		}
	}
}

