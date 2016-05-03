using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace OfficeHoursShared
{
	public partial class EntryPage : ContentPage
	{

		public string Name { get; set; }

		public ActionDirection Direction { get; set; }

		public TimeSpan Time { get; set; }

		List<ActionDirection> DirectionList = new List<ActionDirection>();


		public EntryPage (LogEntryViewModel logEntryVM)
		{

			BindingContext = this;

			if (logEntryVM == null) {
				Name = "Default name";
				Direction = ActionDirection.Entry;
				Time = DateTime.Now.TimeOfDay;		

			} else {
				Name = logEntryVM.Name;
				Direction = logEntryVM.Direction;
				Time = logEntryVM.Time.DateTime.TimeOfDay;
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
		}

		private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
		{
			Direction = DirectionList [((Picker)sender).SelectedIndex];
		}
	}
}

