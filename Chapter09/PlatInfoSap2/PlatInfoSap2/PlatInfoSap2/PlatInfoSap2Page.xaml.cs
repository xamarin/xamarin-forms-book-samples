using System;
using Xamarin.Forms;

namespace PlatInfoSap2
{
    public partial class PlatInfoSap2Page : ContentPage
    {
        public PlatInfoSap2Page ()
        {
            InitializeComponent ();

            PlatformInfo platformInfo = new PlatformInfo();
            modelLabel.Text = platformInfo.GetModel();
            versionLabel.Text = platformInfo.GetVersion();
        }
    }
}
