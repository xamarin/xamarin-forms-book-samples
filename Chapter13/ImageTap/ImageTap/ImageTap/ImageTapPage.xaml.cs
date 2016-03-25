using System;
using Xamarin.Forms;

namespace ImageTap
{
    public partial class ImageTapPage : ContentPage
    {
        public ImageTapPage()
        {
            InitializeComponent();
        }

        void OnImageTapped(object sender, EventArgs args)
        {
            Image image = (Image)sender;
            image.Opacity = 0.75;

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    image.Opacity = 1;
                    return false;
                });

            label.Text = String.Format("Rendered Image is {0} x {1}",
                                       image.Width, image.Height);

        }
    }
}
