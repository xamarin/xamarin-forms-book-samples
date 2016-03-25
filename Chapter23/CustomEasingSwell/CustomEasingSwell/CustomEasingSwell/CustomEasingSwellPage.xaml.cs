using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CustomEasingSwell
{
    public partial class CustomEasingSwellPage : ContentPage
    {
        public CustomEasingSwellPage()
        {
            Resources = new ResourceDictionary();

            Resources.Add("customEase", new Easing(t => -6 * t * t + 7 * t));

            InitializeComponent();
        }
    }
}
