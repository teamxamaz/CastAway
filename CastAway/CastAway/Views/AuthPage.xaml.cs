using System;
using System.Collections.Generic;

using Plugin.Geolocator.Abstractions;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace CastAway.Views
{
	public partial class AuthPage : ContentPage
	{
        Position savedPosition;
		public AuthPage()
		{
			InitializeComponent();
			AuthTwitter.Clicked += OnAuthClicked;
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			if (App.User != null)
            {
                twitterHandle.Text = App.User.ScreenName;
				try
				{
					var locator = CrossGeolocator.Current;
					//locator.DesiredAccuracy = DesiredAccuracy.Value;
					LabelCached.Text = "Getting gps...";

					var position = await locator.GetLastKnownLocationAsync();

					if (position == null)
					{
						LabelCached.Text = "null cached location :(";
						return;
					}

					savedPosition = position;
					//ButtonAddressForPosition.IsEnabled = true;
					LabelCached.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
						position.Timestamp, position.Latitude, position.Longitude,
						position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

				}
				catch (Exception ex)
				{
					await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured for analysis! Thanks.", "OK");
				}
            }
				
		}
		private void OnAuthClicked(object sender, EventArgs e)
		{
			if (App.User == null)
				Navigation.PushModalAsync(new LoginPage());
		}
	}
}
