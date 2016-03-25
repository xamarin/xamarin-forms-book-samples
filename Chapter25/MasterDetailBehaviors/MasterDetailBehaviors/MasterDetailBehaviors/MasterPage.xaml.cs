using System;
using Xamarin.Forms;

namespace MasterDetailBehaviors
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.WinPhone ||
                Device.OS == TargetPlatform.Windows)
            {
                Icon = new FileImageSource
                {
                    File = "Images/ApplicationBar.Select.png"
                };
            }
        }
    }
}
