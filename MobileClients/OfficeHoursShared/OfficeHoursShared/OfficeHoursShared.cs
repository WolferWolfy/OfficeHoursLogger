using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OfficeHoursShared
{
	public class App : Application
	{
		public App ()
		{


			PersistenceManager pm = new PersistenceManager ();

			Auth0User user = pm.RetreiveUserData ();


			if (user != null) {
				MainPage = new NavigationPage (new SummaryPage ());

				var loggedInUser = Auth0Provider.Instance.GetUserData (user.LoginToken);

				if (loggedInUser.LoginToken.access_token != user.LoginToken.access_token) {
					Console.WriteLine ("user udpated");
				}
			}
			else {
				// The root page of your application
				MainPage = new NavigationPage (new HomePage ());
			}


		}

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

