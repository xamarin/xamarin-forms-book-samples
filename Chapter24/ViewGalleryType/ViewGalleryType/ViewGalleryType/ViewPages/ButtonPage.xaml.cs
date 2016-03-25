using System;
using Xamarin.Forms;

namespace ViewGalleryType
{
    public partial class ButtonPage : ContentPage
    {
        public ButtonPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await button.RotateTo(90, 250, Easing.SinOut);
            await button.RotateTo(-90, 500, Easing.SinInOut);
            await button.RotateTo(0, 250, Easing.SinIn);
        }
    }
}
