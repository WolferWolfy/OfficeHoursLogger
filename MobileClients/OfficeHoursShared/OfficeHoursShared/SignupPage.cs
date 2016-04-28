using System;
using Xamarin.Forms;

namespace OfficeHoursShared
{
	public class SignupPage : ContentPage
	{
		public SignupPage ()
		{
			// A new element we're creating here - the Entry element
			// Entry allows us to capture user input
			// We are adding a Placeholder attribute to tell the user
			// which data we want them to enter
			var email = new Entry {
				Placeholder = "Email"
			};

			// Similar to the email entry button, we capture the
			// users password here. To hide the password from being
			// displayed we set the `IsPassword` attribute to true
			var password = new Entry {
				Placeholder = "Password",
				IsPassword = true
			};

			var signupButton = new Button {
				Text = "Sign Up"
			};

			signupButton.Clicked += (object sender, EventArgs e) => {

			};

			Content = new StackLayout {
				Padding = 30,
				Spacing = 10,
				Children = {
					new Label { Text = "Signup for an Office Hours Account", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)), HorizontalOptions = LayoutOptions.Center },
					email,
					password,
					signupButton
				}
			};

			signupButton.Clicked += (object sender, EventArgs e) => {
				// We have created a function that takes the captured email
				// and password and attempts to create a new user account

				bool success = Auth0Provider.Instance.Signup(email.Text, password.Text);

				if (success) {
					DisplayAlert ("Account Created", "Head back to the hompage and login with your new account", "Ok");
				} else {
					DisplayAlert ("Oh No!", "Account could not be created. Do you already have an account? Please try again.", "Ok");
				}
			};
		}
	}
}
