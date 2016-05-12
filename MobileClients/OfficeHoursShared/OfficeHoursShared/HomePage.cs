using System;

using Xamarin.Forms;

namespace OfficeHoursShared
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			var title = new Label {
				Text = "Welcome to Office Hours",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			var aboutButton = new Button {
				Text = "About Us"
			};

			var signupButton = new Button {
				Text = "Signup"
			};

			// Here we are implementing a click event using lambda expressions
			// when a user clicks the `aboutButton` they will navigate to the
			// About Us page.
			aboutButton.Clicked += (object sender, EventArgs e) => {
				Navigation.PushAsync (new AboutPage ());
			};

			// Navigation to the Signup Page (Note: We haven't created this page yet)
			signupButton.Clicked += (object sender, EventArgs e) => {
				Navigation.PushAsync (new SignupPage ());
			};

			var email = new Entry {
				//Placeholder = "E-Mail",
				Text = "wolf01@lunaversum.com"
			};

			var password = new Entry {
				//Placeholder = "Password",
				Text = "password",
				IsPassword = true
			};

			var login = new Button {
				Text = "Login"
			};

			login.Clicked += (sender, e) => {
				// We implemented a login function that accepts
				// two strings, the first being the users email
				// and the send the users password. We get this
				// data from the entry forms we created earlier
				//Login(email.Text, password.Text);

				var user = Auth0Provider.Instance.Login (email.Text, password.Text);

				PersistenceManager pm = new PersistenceManager();
				pm.SaveUserData(user);


				var np = new NavigationPage(new SummaryPage ());
				Navigation.PushModalAsync(np);
			};
				
			Content = new StackLayout {
				Padding = 30,
				Spacing = 10,
				Children = { title, email, password, login, signupButton, aboutButton}
			};
		}
	}
}


