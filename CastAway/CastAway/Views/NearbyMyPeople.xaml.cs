using System;
using System.Collections.Generic;
using CastAway.Controller;
using CastAway.Models;

using Xamarin.Forms;

namespace CastAway.Views
{
    public partial class NearbyMyPeople : ContentPage
    {
        public NearbyMyPeople()
        {
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			if (App.User != null)
			{
				try
				{
                    List<UserDetails> ListOfUsers = await UserController.GetAllUsers(App.User);
                    //CastAway.Helpers.Settings = JsonConvert.SerializeObject(App.User)
                    UserView.ItemsSource = ListOfUsers;
				}
				catch (Exception ex)
				{
					await DisplayAlert("Exception", ex.Message, "Ok");
				}
			}

		}
    }
}
