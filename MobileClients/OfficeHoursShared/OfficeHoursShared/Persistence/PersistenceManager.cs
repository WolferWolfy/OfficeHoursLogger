using System;
using Xamarin.Forms;

namespace OfficeHoursShared
{
	public class PersistenceManager
	{
		public PersistenceManager ()
		{
		}

		public void SaveUserData(Auth0User user) {

			Application.Current.Properties["auth0UserName"] = user.Name;
			Application.Current.Properties["auth0UserPicture"] = user.Picture;
			Application.Current.Properties["auth0UserEmail"] = user.Email;
			Application.Current.Properties["auth0UserLoginTokenIdToken"] = user.LoginToken.id_token;
			Application.Current.Properties["auth0UserLoginTokenAccessToken"] = user.LoginToken.access_token;
			Application.Current.Properties["auth0UserLoginTokenRefreshToken"] = user.LoginToken.refresh_token;
		}
			
		public Auth0User RetreiveUserData() {

			Auth0User user = new Auth0User ();
			user.LoginToken = new LoginToken ();

			if (Application.Current.Properties.ContainsKey ("auth0UserName")) {
				user.Name = Application.Current.Properties ["auth0UserName"] as string;
			} 
			else {
				return null;
			}

			if (Application.Current.Properties.ContainsKey ("auth0UserPicture")) {
				user.Picture = Application.Current.Properties ["auth0UserPicture"] as string;
			}
			if (Application.Current.Properties.ContainsKey ("auth0UserEmail")) {
				user.Email = Application.Current.Properties ["auth0UserEmail"] as string;
			}

			if (Application.Current.Properties.ContainsKey ("auth0UserLoginTokenIdToken")) {
				user.LoginToken.id_token = Application.Current.Properties ["auth0UserLoginTokenIdToken"] as string;
			}
			if (Application.Current.Properties.ContainsKey ("auth0UserLoginTokenAccessToken")) {
				user.LoginToken.access_token = Application.Current.Properties ["auth0UserLoginTokenAccessToken"] as string;
			}
			if (Application.Current.Properties.ContainsKey ("auth0UserLoginTokenRefreshToken")) {
				user.LoginToken.refresh_token = Application.Current.Properties ["auth0UserLoginTokenRefreshToken"] as string;
			}
			return user;
		}
	}
}

