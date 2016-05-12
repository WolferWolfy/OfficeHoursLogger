using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace OfficeHoursShared
{
	public partial class EntryPage : ContentPage
	{
		IOfficeHoursRepository OfficeHoursRepository;

		bool newEntryScenario;

		public string Name { get; set; }
		public ActionDirection Direction { get; set; }
		public TimeSpan Time { get; set; }

		List<ActionDirection> DirectionList = new List<ActionDirection>();

		public LogEntryViewModel LogEntry { get; set; }

		public EntryPage (LogEntryViewModel logEntryVM, bool isNewEntry)
		{
			
			OfficeHoursRepository = RepositoryManager.Repository;

			BindingContext = this;

			LogEntry = logEntryVM;


			if (isNewEntry == true) {
				Name = logEntryVM.Name;
				Direction = ActionDirection.Entry;
				Time = DateTime.Now.TimeOfDay;

				newEntryScenario = true;

			} else {
				Name = logEntryVM.Name;
				Direction = logEntryVM.Direction;
				Time = logEntryVM.Time.DateTime.TimeOfDay;

				newEntryScenario = false;
			}

			InitializeComponent ();	

			EntryDatePicker.Date = logEntryVM.Time.DateTime;
			EntryDatePicker.IsEnabled = isNewEntry;

			UpdatePickerColor ();

			int index = 0;
			foreach (var value in Enum.GetValues(typeof(ActionDirection)))
			{
				DirectionPicker.Items.Add(value.ToString());
				DirectionList.Add ((ActionDirection)value);

				if (logEntryVM != null && (ActionDirection)value == logEntryVM.Direction) {
					DirectionPicker.SelectedIndex = index;
				}
				++index;
			}

			ToolbarItems.Add(new ToolbarItem {
				Text = "Save",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => SaveChanges())
			});

		}

	
		private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
		{
			Direction = DirectionList [((Picker)sender).SelectedIndex];
			UpdatePickerColor ();
		}

		private void UpdatePickerColor() {
			DirectionPicker.BackgroundColor = (Direction == ActionDirection.Entry ? Color.Teal : Color.Maroon).MultiplyAlpha(0.44);
		}

		private void SaveChanges() {

			bool dirty = false;

			if (LogEntry.Name != Name) {
				LogEntry.Name = Name;
				dirty = true;
			}
			if (LogEntry.Direction != Direction) {
				LogEntry.Direction = Direction;
				dirty = true;
			}
				
			if (LogEntry.Time.Hour != Time.Hours || LogEntry.Time.Minute != Time.Minutes) {
				LogEntry.Time.Hour = Time.Hours;
				LogEntry.Time.Minute = Time.Minutes;
				LogEntry.Time.Second = 0;
				dirty = true;
			}

			if (LogEntry.Time.Year != EntryDatePicker.Date.Year || LogEntry.Time.Month != EntryDatePicker.Date.Month || LogEntry.Time.Day != EntryDatePicker.Date.Day) {
				LogEntry.Time.Year = EntryDatePicker.Date.Year;
				LogEntry.Time.Month = EntryDatePicker.Date.Month;
				LogEntry.Time.Day = EntryDatePicker.Date.Day;
				dirty = true;
			}


			if (newEntryScenario) {
				OfficeHoursRepository.AddEntry (LogEntry);
			}
			else if (dirty) {
				OfficeHoursRepository.UpdateEntry (LogEntry);
			}

			Navigation.PopAsync ();
		}
	}
}

