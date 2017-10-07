using System;
using CastAway.Models;
using Xamarin.Forms;
using CastAway.Views;

namespace CastAway
{
	public class App : Application
	{
		//static NavigationPage _NavigationPage;
		public static UserDetails User;
        public static MessageListPage _MessageList;

		//public static Page GetMainPage()
		//{
		//	_MessageList = _MessageList ?? new MessageListPage();
		//	_NavigationPage = new NavigationPage(_MessageList);
		//	return _NavigationPage;
		//}
		public App ()
		{
            MainPage= new NavigationPage(new AuthPage()); //GetMainPage() ;
		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
				{
                    //_NavigationPage.Navigation.PopToRootAsync();
                    
                    //_NavigationPage.Navigation.PushModalAsync(_MessageList);

                    Application.Current.MainPage = new NavigationPage(new AuthPage());
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

