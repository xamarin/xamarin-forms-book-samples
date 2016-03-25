using System;
using Xamarin.Forms;

namespace StackManipulation
{
    public class PageC : ContentPage
    {
        public PageC()
        {
            Button button = new Button
            {
                Text = "Go to Page D",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            button.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new PageD());
            };

            Title = "Page C";
            Content = button;
        }
    }
}
