using System;
using XamarinFormDemo;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormDemo.iOS;
using Xamarin.Auth;

[assembly: ExportRenderer (typeof(FacebookLoginForm), typeof(FacebookLoginRenderer))]
namespace XamarinFormDemo.iOS
{
	public class FacebookLoginRenderer : PageRenderer
	{
		string FacebookAppID = "737325066422364";
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			var auth = new OAuth2Authenticator(
				clientId: FacebookAppID,
				scope: "",
				authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

			auth.Completed += (sender, eventArgs) =>
			{
				// We presented the UI, so it's up to us to dismiss it on iOS.
				DismissViewController(true, null);
				// you may want to also do something to dismiss THIS viewcontroller, 
				// or else you'll keep seeing the login screen              

				if (eventArgs.IsAuthenticated)
				{
					// Use eventArgs.Account to do wonderful things
					// ...such as saving the token, and then getting some more detailed user info from the API
					App.SaveToken = eventArgs.Account.Properties["access_token"];
				}
				else
				{
					// The user cancelled
				}
			};

			PresentViewController((UIKit.UIViewController)auth.GetUI(), true, null);
		}
	}
}

