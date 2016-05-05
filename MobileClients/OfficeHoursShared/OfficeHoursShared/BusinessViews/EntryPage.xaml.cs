using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace OfficeHoursShared
{
	public partial class EntryPage : ContentPage
	{
		IOfficeHoursRepository OfficeHoursRepository;

		public string Name { get; set; }
		public ActionDirection Direction { get; set; }
		public TimeSpan Time { get; set; }

		List<ActionDirection> DirectionList = new List<ActionDirection>();

		public LogEntryViewModel LogEntry { get; set; }

		public EntryPage (LogEntryViewModel logEntryVM)
		{
			
			OfficeHoursRepository = RepositoryManager.Repository;

			BindingContext = this;

			if (logEntryVM == null) {
				Name = "Default name";
				Direction = ActionDirection.Entry;
				Time = DateTime.Now.TimeOfDay;

				LogEntry = new LogEntryViewModel ();

			} else {
				Name = logEntryVM.Name;
				Direction = logEntryVM.Direction;
				Time = logEntryVM.Time.DateTime.TimeOfDay;

				LogEntry = logEntryVM;
			}

			InitializeComponent ();	

	
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
				
			if (LogEntry.Time.Hour != Time.Hours || LogEntry.Time.Minute != Time.Minutes || LogEntry.Time.Second != Time.Seconds) {
				LogEntry.Time.Hour = Time.Hours;
				LogEntry.Time.Minute = Time.Minutes;
				LogEntry.Time.Second = Time.Seconds;
				dirty = true;
			}



			//DisplayAlert ("Saved!", "Changes to entry are saved.","ok", "still ok");
			//DisplayActionSheet
			if (dirty) {
				OfficeHoursRepository.UpdateEntry (LogEntry);
			}

			Navigation.PopAsync ();
		}
	}
}

