using System;
using Xamarin.Forms;

namespace PlatformBitmaps
{
    public class PlatformBitmapsPage : ContentPage
    {
        public PlatformBitmapsPage()
        {
            FileImageSource imgSrc = new FileImageSource();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    imgSrc.File = "Icon-Small-40.png";
                    break;

                case Device.Android:
                    imgSrc.File = "icon.png";
                    break;

                case Device.WinRT:
                case Device.WinPhone:
                case Device.UWP:
                    imgSrc.File = "Assets/StoreLogo.png";
                    break;
            }

            Image image = new Image
            {
                Source = imgSrc,
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
