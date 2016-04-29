using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;

namespace OfficeHoursShared
{
	public partial class SummaryPage : ContentPage
	{
		ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

		public SummaryPage ()
		{
			InitializeComponent ();

			Title = "Summary";
			BarChart.Source = PlatformImageResource ("temp_bar_chart.png");

			// if moved to OfficeHoursShared.iOS/Resources:
			// BarChart.Source = ImageSource.FromFile("temp_bar_chart.png");

			EmployeeView.ItemsSource = employees;

			employees.Add(new Employee{ DisplayName="Rob Finnerty"});
			employees.Add(new Employee{ DisplayName="Bill Wrestler"});
			employees.Add(new Employee{ DisplayName="Dr. Geri-Beth Hooper"});
			employees.Add(new Employee{ DisplayName="Dr. Keith Joyce-Purdy"});
			employees.Add(new Employee{ DisplayName="Sheri Spruce"});
			employees.Add(new Employee{ DisplayName="Burt Indybrick"});
	
		}


		private string _baseResource;
		public string BaseResource
		{
			get
			{
				return _baseResource ?? (_baseResource = Assembly.GetExecutingAssembly ().FullName.Split (',').FirstOrDefault ());
			}
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert ("Item Selected", ((Employee) e.SelectedItem).DisplayName, "Ok");
			//((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

			Employee selected = (Employee) e.SelectedItem;

			Navigation.PushAsync(new MonthPage(selected.DisplayName));
		}

		private ImageSource PlatformImageResource(string resource)
		{
			var br = BaseResource;
			return ImageSource.FromResource(BaseResource + "." + resource);
		}
	}

	public class Employee{
		public string DisplayName {get; set;}
	}
}

