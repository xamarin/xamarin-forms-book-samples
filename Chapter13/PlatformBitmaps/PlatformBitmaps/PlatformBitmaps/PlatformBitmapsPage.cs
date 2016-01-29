using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

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
                    // Interim fix for Windows Runtime projects: 
                    //      ForPlatform class from Xamarin.FormsBook.Toolkit
                    // -------------------------------------------------------------------------

                    File = new ForPlatform<string>
                    {
                        iOS = "Icon-Small-40.png",
                        Android = "icon.png",
                        WinPhone = "Assets/ApplicationIcon.png",
                        WindowsStore = "Assets/StoreLogo.png",
                        WindowsPhoneStore = "Assets/StoreLogo.png"
                    }

                    // File =   Device.OnPlatform(iOS: "Icon-Small-40.png",
                    //                            Android: "icon.png",
                    //                            WinPhone: "Assets/ApplicationIcon.png")
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
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
