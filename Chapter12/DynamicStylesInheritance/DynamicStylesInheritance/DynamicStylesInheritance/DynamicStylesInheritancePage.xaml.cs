using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DynamicStylesInheritance
{
    public partial class DynamicStylesInheritancePage : ContentPage
    {
        public DynamicStylesInheritancePage()
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
