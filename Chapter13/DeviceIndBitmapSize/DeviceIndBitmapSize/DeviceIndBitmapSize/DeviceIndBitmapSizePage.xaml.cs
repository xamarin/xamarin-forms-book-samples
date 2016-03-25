using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DeviceIndBitmapSize
{
    public partial class DeviceIndBitmapSizePage : ContentPage
    {
        public DeviceIndBitmapSizePage()
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
