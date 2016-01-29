using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DeviceIndependentBitmapSize
{
    public partial class DeviceIndependentBitmapSizePage : ContentPage
    {
        public DeviceIndependentBitmapSizePage()
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
