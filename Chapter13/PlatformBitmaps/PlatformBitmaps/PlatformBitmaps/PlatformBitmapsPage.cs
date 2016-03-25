using System;
using Xamarin.Forms;

namespace PlatformBitmaps
{
    public class PlatformBitmapsPage : ContentPage
    {
        public PlatformBitmapsPage()
        {
            Image image = new Image
            {
                Source = new FileImageSource
                {
                    File = Device.OnPlatform(iOS: "Icon-Small-40.png",
                                             Android: "icon.png",
                                             WinPhone: "Assets/StoreLogo.png")
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            image.SizeChanged += (sender, args) =>
                {
                    label.Text = String.Format("Rendered size = {0} x {1}",
                                               image.Width, image.Height);
                };

            Content = new StackLayout
            {
                Children = 
                {
                    image,
                    label
                }
            };
        }
    }
}
