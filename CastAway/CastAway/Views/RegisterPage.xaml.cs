using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastAway.Models;
using CastAway.Controller;

using Plugin.Geolocator.Abstractions;
using Plugin.Geolocator;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace CastAway.Views
{
	public partial class RegisterPage : ContentPage
	{
        public Position savedPosition;
		public RegisterPage()
		{
			InitializeComponent();

			btnRegister.Clicked += btnRegister_Clicked;
			if (pickerLanguage.Items.Count <= 0)
			{
				BindSupportedLanguages();
			}
		}
		private void BindSupportedLanguages()
		{
			pickerLanguage.ItemsSource = Constants.SupportedLanguages.Trim().Split(',').ToList();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			if (App.User != null )
			{
				twitterHandle.Text = App.User.ScreenName;
				try
				{
					var locator = CrossGeolocator.Current;
					//locator.DesiredAccuracy = DesiredAccuracy.Value;
					LabelCached.Text = "Getting gps...";

                    var position = await locator.GetPositionAsync();

					if (position == null)
					{
						LabelCached.Text = "null cached location :(";
						//return;
					}

					savedPosition = position;
					//ButtonAddressForPosition.IsEnabled = true;
					LabelCached.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
						position.Timestamp, position.Latitude, position.Longitude,
						position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

                    var addrr = await locator.GetAddressesForPositionAsync(position);
                    LabelCached.Text = $"{addrr.FirstOrDefault().Locality},{addrr.FirstOrDefault().CountryName}";
				}
				catch (Exception ex)
				{
                    await DisplayAlert("Uh oh", ex.Message, "OK");
				}
			}

		}

		private async void btnRegister_Clicked(object sender, EventArgs e)
		{
            if (!string.IsNullOrWhiteSpace(EntryName.Text))
			{
                App.User.Locality = LabelCached.Text;
                App.User.LocationLat = savedPosition.Latitude.ToString();
                App.User.LocationLong = savedPosition.Longitude.ToString();
                App.User.FullName = EntryName.Text;
                App.User.Language = pickerLanguage.SelectedItem.ToString();

                try
                {
                    bool IsRegister = await UserController.InsertUserData(App.User);
                    //CastAway.Helpers.Settings = JsonConvert.SerializeObject(App.User)
					await DisplayAlert("Register User", "Your details have been registered successfully.", "Yay!");
                    Application.Current.MainPage = new NavigationPage(new MainMenu())
					{
						BarTextColor = Color.LightGoldenrodYellow
					};
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Exception", ex.Message, "Ok");
                }
				//await RegisterUser(person);
				
			}

		}
	}
}
