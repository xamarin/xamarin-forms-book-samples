using System;
using Xamarin.Forms;

namespace FadingEntrance
{
    public partial class FadingEntrancePage : ContentPage
    {
        public FadingEntrancePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            stackLayout.Opacity = 0;
            stackLayout.FadeTo(1, 3000);
        }
    }
}
