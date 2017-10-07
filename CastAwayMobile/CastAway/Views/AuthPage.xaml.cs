using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CastAway.Views
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            AuthTwitter.Clicked +=OnAuthClicked;
        }
		protected override void OnAppearing()
		{
			base.OnAppearing();
            if (App.User != null)
                twitterHandle.Text = App.User.ScreenName;
            else
                Navigation.PushModalAsync(new LoginPage());
			
		}
		private void OnAuthClicked(object sender, EventArgs e)
		{
            if(App.User==null)
                Navigation.PushModalAsync(new LoginPage());
		}
	}
}
