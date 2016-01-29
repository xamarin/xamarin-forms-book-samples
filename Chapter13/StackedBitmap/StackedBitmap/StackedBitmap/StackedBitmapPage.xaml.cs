using System;
using Xamarin.Forms;

namespace StackedBitmap
{
    public partial class StackedBitmapPage : ContentPage
    {
        public StackedBitmapPage()
        {
            InitializeComponent();
        }

        void OnImageSizeChanged(object sender, EventArgs args)
        {
            Image image = (Image)sender;
            label.Text = String.Format("Rendered size = {0:F0} x {1:F0}", 
                                       image.Width, image.Height);
        }
    }
}
