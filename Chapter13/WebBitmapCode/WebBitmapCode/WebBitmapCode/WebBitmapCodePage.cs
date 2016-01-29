using System;
using Xamarin.Forms;

namespace WebBitmapCode
{
    public class WebBitmapCodePage : ContentPage
    {
        public WebBitmapCodePage()
        {
            string uri = "http://developer.xamarin.com/demo/IMG_1415.JPG";

            Content = new Image
            {
                 Source = ImageSource.FromUri(new Uri(uri)),
            };
        }
    }
}
