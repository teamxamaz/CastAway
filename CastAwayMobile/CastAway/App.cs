using System;
using CastAway.Models;
using Xamarin.Forms;
using CastAway.Views;

namespace CastAway
{
	public class App : Application
	{
		public static UserDetails User;
		public App ()
		{
            MainPage= new NavigationPage(new AuthPage()); 
		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
				{
                    Application.Current.MainPage = new NavigationPage(new RegisterPage());
				});
			}
		}

		public static Action LoginCancelledAction
		{
			get
			{
				return new Action(() =>
				{
					//_NavigationPage.Navigation.PopToRootAsync();

					//_NavigationPage.Navigation.PushModalAsync(_MessageList);
                    Application.Current.MainPage.DisplayAlert("Cancelled login","why did you cancel login?","sorry!");
					Application.Current.MainPage = new NavigationPage(new AuthPage());
				});
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

