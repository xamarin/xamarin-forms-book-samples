using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomCubicEase
{
    public partial class CustomCubicEasePage : ContentPage
    {
        public CustomCubicEasePage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Func<double, double> customEase = t => 9 * t * t * t - 13.5 * t * t + 5.5 * t;

            double scale = Math.Min(Width / button.Width, Height / button.Height);
            await button.ScaleTo(scale, 1000, customEase);
            await Task.Delay(1000);
            await button.ScaleTo(1, 1000, customEase);
        }
    }
}

