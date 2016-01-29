using System;
using Xamarin.Forms;

namespace DynamicStyles
{
    public partial class DynamicStylesPage : ContentPage
    {
        public DynamicStylesPage()
        {
            InitializeComponent();
        }

        void OnButton1Clicked(object sender, EventArgs args)
        {
            Resources["buttonStyle"] = Resources["buttonStyle1"];
        }

        void OnButton2Clicked(object sender, EventArgs args)
        {
            Resources["buttonStyle"] = Resources["buttonStyle2"];
        }

        void OnButton3Clicked(object sender, EventArgs args)
        {
            Resources["buttonStyle"] = Resources["buttonStyle3"];
        }

        void OnResetButtonClicked(object sender, EventArgs args)
        {
            Resources["buttonStyle"] = null;
        }
    }
}
