using System;
using Xamarin.Forms;

namespace SwingingEntrance
{
    public partial class SwingingEntrancePage : ContentPage
    {
        public SwingingEntrancePage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            stackLayout.AnchorX = 0;
            stackLayout.RotationY = 180;
            await stackLayout.RotateYTo(0, 1000, Easing.CubicOut);
            stackLayout.AnchorX = 0.5;
        }
    }
}
