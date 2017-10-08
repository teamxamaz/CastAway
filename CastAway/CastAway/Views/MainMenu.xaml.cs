using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CastAway.Views
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
            Title = $"{App.User.ScreenName}'s Dashboard";
        }
        public async void OnTapSlangs(object sender, EventArgs args)
		{
            await DisplayAlert("Hold on!","In The Implementation","I can wait");
		}
		public async void OnTapImageTrans(object sender, EventArgs args)
		{
            await DisplayAlert("Hold on!", "In The Implementation", "I can wait");
		}
		public async void OnTapCustomTrans(object sender, EventArgs args)
		{
            await DisplayAlert("Hold on!", "In The Implementation", "I can wait");
		}
		public async void OnTapMyPeople(object sender, EventArgs args)
		{
            await Navigation.PushAsync(new NearbyMyPeople());
		}
		public async void OnTapProfile(object sender, EventArgs args)
		{
            await DisplayAlert("Hold on!", "In The Implementation", "I can wait");
		}
		public async void OnTapICanHelp(object sender, EventArgs args)
		{
            await DisplayAlert("Hold on!", "In The Implementation", "I can wait");
		}
    }
}
