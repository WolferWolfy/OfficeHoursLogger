using System;

using Xamarin.Forms;

namespace OfficeHours
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
		}

		public static Page GetSecondPage ()
		{
			Button button1 = new Button { Text = "Click to push" };
			var formsPage =  new NavigationPage (new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
						button1				
					}
				}
			});

			button1.Clicked += (s, e) => formsPage.PushAsync(new Page());

			return formsPage;
		}

	/*	public App ()
		{
			MainPage = new NavigationPage (new MySecondPage ());
		}*/

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

