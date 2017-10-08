using System;

using Xamarin.Forms;

namespace CastAway.Views
{
    public class MessageListPage : ContentPage
    {
        public MessageListPage()
        {
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children =
			{
				new Label
				{
                        HorizontalTextAlignment = TextAlignment.Center,
					Text = "Welcome to Xamarin!!"
				}
			}
			};
        }
    }
}

