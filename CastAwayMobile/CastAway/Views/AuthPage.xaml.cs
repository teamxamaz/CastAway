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
            Navigation.PushModalAsync(new LoginPage());
        }
		protected override void OnAppearing()
		{
			base.OnAppearing();
            if (App.User != null)
                twitterHandle.Text = App.User.ScreenName;
		}
		private void OnAuthClicked(object sender, EventArgs e)
		{
            if(App.User==null)
                Navigation.PushModalAsync(new LoginPage());
		}
	}
}
