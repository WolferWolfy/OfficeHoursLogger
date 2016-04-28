using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace OfficeHoursShared
{
	public class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			var title = new Label {
				Text = "About Us",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			var description = new Label {
				Text = "Office Hours aims to log, inspect time spent in the office. It is a learning project for various techniques. ASP.NET Core, Angular 2, Xamarin, Swift."
			};

			var blogTitle = new Label {
				Text = "In The News",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			List<string> articles = new List<string> {
				"XSCP work in progress",
				"XamarinSCP inital commit in GitHub",
				"Xamarin Shared Login working",
				"Angular 2 WebPage is working",
				"Office Hours Server code is runnable"
			};

			ListView articlesView = new ListView {
				ItemsSource = articles
			};

			Content = new StackLayout {
				Padding = 30,
				Spacing = 10,
				Children = { title, description, blogTitle, articlesView }
			};
		}
	}
}


