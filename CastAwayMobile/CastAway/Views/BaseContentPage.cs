using System;

using Xamarin.Forms;

namespace CastAway.Views
{
    public class BaseContentPage : ContentPage
    {
		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (App.User == null)
			{
				Navigation.PushModalAsync(new LoginPage());
			}
		}
    }
}

