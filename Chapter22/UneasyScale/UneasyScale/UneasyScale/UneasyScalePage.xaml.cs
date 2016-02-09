using System;
using Xamarin.Forms;

namespace UneasyScale
{
    public partial class UneasyScalePage : ContentPage
    {
        Random random = new Random();

        public UneasyScalePage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            double scale = Math.Min(Width / button.Width, Height / button.Height);
            await button.ScaleTo(scale, 1000, new Easing(t => (int)(5 * t) / 5.0));
            await button.ScaleTo(1, 1000, (Easing)RandomEase);
        }

        double RandomEase(double t)
        {
            return t == 0 || t == 1 ? t : t + 0.25 * (random.NextDouble() - 0.5);
        }
    }
}
