using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Auth0Client.iOS.Sample;

namespace OfficeHours.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
	/*	public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
		*/
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var root = new MonoTouch.Dialog.RootElement ("Auth0Client - iOS Sample");
			var nav = new UINavigationController (new Auth0Client_iOS_SampleViewController (root));
			// If you have defined a view, add it here:
			window.RootViewController = nav;

			// make the window visible
			window.MakeKeyAndVisible ();
			return true;
		}
	}
}

