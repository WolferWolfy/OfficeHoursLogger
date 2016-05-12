using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace OfficeHoursShared
{
	public class Auth0Provider
	{
		private static Auth0Provider instance;

		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		private string Domain { get; set; }
		private string ClientId { get; set; }
		private string Connection { get; set; }
		private string Device { get; set; }

		public Auth0User User {
			get;
			private set;
		}

		public static Auth0Provider Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new Auth0Provider();
				}
				return instance;
			}
		}

		private Auth0Provider ()
		{
			Domain = "https://wolfer.eu.auth0.com";
			ClientId = "eFNIC2E6bz8PPju7fFoMHSD9SnWVgoXM"; // officehours
			Connection = "OfficeHoursDB";
			Device = "mobile-xamarin";

		}

		public Auth0User Login(string userName, string password) {

			var client = new RestClient(Domain);
			var request = new RestRequest("oauth/ro", Method.POST);
			request.AddParameter("client_id", ClientId);
			request.AddParameter("username", userName);
			request.AddParameter("password", password);
			request.AddParameter("connection", Connection);
			request.AddParameter("grant_type", "password");
			request.AddParameter("scope","openid offline_access");
			request.AddParameter ("device", Device);

			IRestResponse response = client.Execute(request);

			LoginToken token = JsonConvert.DeserializeObject<LoginToken> (response.Content);

			// We check to see if we received an `id_token` and if we did make a secondary call
			// to get the user data. If we did not receive an `id_token` we can safely assume
			// that the authentication failed so we display an error message telling the user
			// to try again.
			if (token.id_token != null) {
				//	Application.Current.Properties ["id_token"] = token.id_token;
				//	Application.Current.Properties ["access_token"] = token.access_token;
				//	Application.Current.Properties ["refresh_token"] = token.refresh_token;
				User = GetUserData (token);
				return User;
			} else {
				return null;
				//DisplayAlert ("Oh No!", "It's seems that you have entered an incorrect email or password. Please try again.", "OK");
			};
		}

		public bool Signup(string email, string password) {

			var client = new RestClient(Domain);
			var request = new RestRequest("dbconnections/signup", Method.POST);

			request.AddParameter("client_id", ClientId);
			request.AddParameter("email", email);
			request.AddParameter("password", password);
			request.AddParameter("connection", Connection);

			IRestResponse response = client.Execute(request);
			// Once the request is executed we capture the response.
			// If we get a `user_id`, we know that the account has been created
			// and display an appropriate message. If we do not get a `user_id`
			// we know something went wrong, so we ask the user if they already have
			// an account and if not to try again.

				UserSignup user = JsonConvert.DeserializeObject<UserSignup> (response.Content);
		/*	if (user.user_id != null) {
				DisplayAlert ("Account Created", "Head back to the hompage and login with your new account", "Ok");
			} else {
				DisplayAlert ("Oh No!", "Account could not be created. Do you already have an account? Please try again.", "Ok");
			}*/

			return user.Email != null;
		}


		public Auth0User GetUserData(LoginToken loginToken){
			var client = new RestClient("https://wolfer.eu.auth0.com");
			var request = new RestRequest("tokeninfo", Method.GET);

			var hasExpired = Auth0Provider.HasExpired (loginToken.id_token);
			if (hasExpired) {
				loginToken = GetNewToken(loginToken);				
			}

			request.AddParameter ("id_token", loginToken.id_token);

			IRestResponse response = client.Execute (request);

			Auth0User user = JsonConvert.DeserializeObject<Auth0User> (response.Content);

			// Once the call executes, we capture the user data in the
			// `Application.Current` namespace which is globally available in Xamarin
			//Application.Current.Properties ["email"] = user.email;
			//Application.Current.Properties ["picture"] = user.picture;

			user.LoginToken = loginToken;

			// Finally, we navigate the user the the Orders page
			//Navigation.PushModalAsync (new OrdersPage ());

			User = user;
			return user;
		}

		private LoginToken GetNewToken(LoginToken loginToken) {

			var client = new RestClient(Domain);
			var request = new RestRequest("delegation", Method.POST);
			request.AddParameter("client_id", ClientId);
			request.AddParameter("refresh_token", loginToken.refresh_token);
			request.AddParameter("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer");
			request.AddParameter ("api_type", "app");
			request.AddParameter("scope","openid");
			// We execute the request and capture the response
			// in a variable called `response`
			IRestResponse response = client.Execute(request);

			LoginToken token = JsonConvert.DeserializeObject<LoginToken> (response.Content);

			return token;
		}

		public static bool HasExpired(string jwt)
		{
			if (jwt == null)
			{
				throw new ArgumentNullException("jwt");
			}

			var parts = jwt.Split(new []{ "." }, StringSplitOptions.RemoveEmptyEntries);

			if (parts.Length != 3)
			{
				throw new ArgumentException("jwt is not well formed. Check http://jwt.io");
			}

			var length = parts [1].Length;
			// padding
			var partialBody = parts [1]
				.PadRight (length + (4 - length % 4) % 4, '=')
				.Replace ('-', '+')
				.Replace ('_', '/');

			var body = Convert.FromBase64String(partialBody);
			var obj = JObject.Parse(Encoding.UTF8.GetString(body, 0, body.Length));
			JToken exp;
			if (obj.TryGetValue("exp", out exp))
			{
				double seconds = exp.Value<double>();
				var expDate = Epoch.AddSeconds(seconds);

				return expDate <= DateTime.UtcNow;
			}

			return false;
		}

	}

	public class LoginToken{
		public string id_token { get; set; }
		public string access_token {get; set; }
		public string refresh_token { get; set; }
	}

	public class Auth0User {
		public string Name { get; set;}
		public string Picture { get; set;}
		public string Email { get; set; }

		public LoginToken LoginToken { get; set; }
	}

	public class UserSignup {
		public string Email { get; set; }
	}
}

