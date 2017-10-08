using System;
using Android.App;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CastAway.Droid;
using CastAway.Views;
using CastAway.Models;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace CastAway.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        bool showLogin = true;
		protected override void OnElementPropertyChanged(object s, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(s, e);

			var activity = this.Context as Activity;

			if (showLogin && App.User == null)
			{
				showLogin = false;

				//Twitter with oauth1 
				var auth = new OAuth1Authenticator(
                    consumerKey: Constants.TwitterConsumerKey,
                    consumerSecret: Constants.TwitterSecret,
					requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), // the redirect URL for the service
					authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), // the auth URL for the service
					accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                    callbackUrl: new Uri(Constants.CallbackUrl)
				);

				auth.Completed += (sender, eventArgs) =>
				{
					if (eventArgs.IsAuthenticated)
					{
						App.User = new Models.UserDetails();
						// Use eventArgs.Account to do wonderful things
						App.User.Token = eventArgs.Account.Properties["oauth_token"];
						App.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
						App.User.TwitterId = eventArgs.Account.Properties["user_id"];
						App.User.ScreenName = eventArgs.Account.Properties["screen_name"];

						App.SuccessfulLoginAction.Invoke();
					}
					else
					{
						App.LoginCancelledAction.Invoke();
					}
				};

				activity.StartActivity(auth.GetUI(activity));
			}
		}
    }
}
