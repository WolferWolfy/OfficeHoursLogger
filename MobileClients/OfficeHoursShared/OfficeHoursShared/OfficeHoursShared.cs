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

