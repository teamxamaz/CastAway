using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CastAway.Views
{
    public partial class RegisterPage : ContentPage
    {
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

		private async void btnRegister_Clicked(object sender, EventArgs e)
		{
            if (entryFirstname.Text == string.Empty  )
			{
				//var person = new Person
				//{
				//	Firstname = entryFirstname.Text,
				//	Lastname = entryLastname.Text,
				//	Language = pickerLanguage.SelectedItem.ToString(),
				//	Location = entryLocation.Text
				//};
				//await RegisterUser(person);
				await DisplayAlert("Register User", "Your details have been registered successfully.", "Done");
			}

		}
    }
}
