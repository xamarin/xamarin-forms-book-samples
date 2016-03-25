using System;
using Xamarin.Forms;

namespace StackManipulation
{
    public class PageB : ContentPage
    {
        public PageB()
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

            Title = "Page B";
            Content = button;
        }
    }
}
