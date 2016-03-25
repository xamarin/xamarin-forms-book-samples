using System;
using Xamarin.Forms;

namespace ModelessAndModal
{
    public class ModelessPage : ContentPage
    {
        public ModelessPage()
        {
            Title = "Modeless Page";

            Button goBackButton = new Button
            {
                Text = "Back to Main",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            goBackButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };

            Content = goBackButton;
        }
    }
}
