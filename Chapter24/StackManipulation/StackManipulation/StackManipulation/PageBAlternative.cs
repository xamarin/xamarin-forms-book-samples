using System;
using Xamarin.Forms;

namespace StackManipulation
{
    public class PageBAlternative : ContentPage
    {
        public PageBAlternative()
        {
            Button button = new Button
            {
                Text = "Go to Page C",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            button.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new PageC());
            };

            Title = "Page B Alt";
            Content = button;
        }
    }
}
