using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BounceButton
{
    public partial class BounceButtonPage : ContentPage
    {
        public BounceButtonPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await button.TranslateTo(0, (Height - button.Height) / 2, 1000, Easing.BounceOut);
            await Task.Delay(2000);
            await button.TranslateTo(0, 0, 1000, Easing.SpringOut);
        }
    }
}
