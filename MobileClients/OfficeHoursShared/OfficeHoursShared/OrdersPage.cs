using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace OfficeHoursShared
{
	public class OrdersPage : ContentPage
	{
		public OrdersPage ()
		{
			Auth0User user = Application.Current.Properties ["auth0User"] as Auth0User;

			// We've also created a new class to hold the cake information.
			List<Cake> cakes = new List<Cake> {
				new Cake ("Chocolate Overload", 15.99),
				new Cake ("Red Velvet Cake", 19.99),
				new Cake ("Strawberry Fusion", 14.99)
			};

			// Instead of using the StackLayout like in the about page
			// we've opted to use a GridLayout to have more flexibility
			Grid grid = new Grid{
				Padding = 30
			};

			// The GridLayout adds elements slightly differently
			// The first parameter is the element we are adding -
			// in this case we create an anonymous Image.
			// Additionally, we specify where we want the image to
			// be displayed in the grid. Here we've chosen 0, 0 which
			// means the image will be placed in the top left corner
			grid.Children.Add(new Image
				{
					Aspect = Aspect.AspectFit,
					WidthRequest = 60,
					HeightRequest = 60,
					Source = ImageSource.FromUri(new Uri(user.Picture)),
				}, 0,0 );

			grid.Children.Add(new Label
				{
					Text = user.Email,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				}, 1, 0);

			// We loop through the available cakes and create a
			// button for each.
			for (var i = 0; i < cakes.Count; i++) {
				Button button = new Button {
					Text = cakes [i].Name + " ($" + cakes [i].Price + ")",
					VerticalOptions = LayoutOptions.Center,
				};

				// We implement a general click event that displays a popup
				// saying that an order was placed
				// Note: In a real world scenario you would likely use a closure
				// if you were implementing this functionality - but for simplicity
				// sake we just kept it simple.
				button.Clicked += (object sender, EventArgs e) => {
					DisplayAlert ("Order Placed", "Your cake order has been placed and will arrive in 15 minutes", "OK");
				};

				// We add the buttons to the grid. In this case
				// we pass additional parameters to have greater
				// control over how the content is displayed
				grid.Children.Add(button, 0, 2, i+1, i+3);
			}

			// Finally we pass our grid into the Content variable
			Content = grid;
		}

	}


	public class Cake {
		public string Name { get; set;}
		public double Price { get; set;}

		public Cake(string name, double price){
			this.Name = name;
			this.Price = price;
		}
	}
}


