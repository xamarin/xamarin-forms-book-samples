using System;
using Xamarin.Forms;

namespace MetricalBoxView
{
    public class MetricalBoxViewPage : ContentPage
    {
        public MetricalBoxViewPage()
        {
            Content = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = 64,
                HeightRequest = 160,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
