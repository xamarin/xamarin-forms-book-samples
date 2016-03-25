using System;
using Xamarin.Forms;

namespace ModelessAndModal
{
    public class ModalPage : ContentPage
    {
        public ModalPage()
        {
            Title = "Modal Page";

            Button goBackButton = new Button
            {
                Text = "Back to Main",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            goBackButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopModalAsync();
            };

            Content = goBackButton;
        }
    }
}
