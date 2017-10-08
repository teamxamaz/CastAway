using Xamarin.Forms;
using CastAway.Models;
using CastAway.Views;
using System;
using Newtonsoft.Json;

namespace CastAway
{
    public partial class App : Application
    {
        public static UserDetails User;
		public App()
		{
            if(string.IsNullOrWhiteSpace(Helpers.Settings.GeneralSettings)) 
                MainPage = new NavigationPage(new AuthPage()) 
                { 
                    BarTextColor = Color.LightGoldenrodYellow
                };
            else
            {
                try
                {
                    UserDetails dynamicuserobject = JsonConvert.DeserializeObject<UserDetails>(Helpers.Settings.GeneralSettings);
                    User = dynamicuserobject;
                    MainPage = new NavigationPage(new MainMenu())
					{
						BarTextColor = Color.LightGoldenrodYellow
					};
                }
                catch (Exception)
                {
                    MainPage = new NavigationPage(new AuthPage())
                    {
                        BarTextColor = Color.LightGoldenrodYellow
					};
                }
            }

		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
				{
                    
					Application.Current.MainPage = new NavigationPage(new RegisterPage())
					{
						BarTextColor = Color.LightGoldenrodYellow
					};
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
					Application.Current.MainPage.DisplayAlert("Cancelled login", "why did you cancel login?", "sorry!");
					Application.Current.MainPage = new NavigationPage(new AuthPage())
					{
						BarTextColor = Color.LightGoldenrodYellow
					};
				});
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

