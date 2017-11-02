using System;
using Xamarin.Forms;

namespace MasterDetailBehaviors
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.WinRT)
            {
                Icon = new FileImageSource
                {
                    File = "Images/ApplicationBar.Select.png"
                };
            }
        }
    }
}
