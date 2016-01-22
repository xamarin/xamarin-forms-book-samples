using System;
using Xamarin.Forms;

namespace FramedText
{
    public class FramedTextPage : ContentPage
    {
        public FramedTextPage()
        {
            BackgroundColor = Color.Aqua;

            Content = new Frame
            {
                OutlineColor = Color.Black,
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Content = new Label
                {
                    Text = "I've been framed!",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    FontAttributes = FontAttributes.Italic,
                    TextColor = Color.Blue
                }
            };
        }
    }
}
