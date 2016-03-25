using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwingButton
{
    public partial class SwingButtonPage : ContentPage
    {
        public SwingButtonPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            // Swing down from lower-left corner.
            button.AnchorX = 0;
            button.AnchorY = 1;

            await button.RotateTo(90, 3000, 
                new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));

            // Drop to the bottom of the screen.
            await button.TranslateTo(0, (Height - button.Height) / 2 - button.Width, 
                                     1000, Easing.BounceOut);

            // Prepare AnchorX and AnchorY for next rotation.
            button.AnchorX = 1;
            button.AnchorY = 0;

            // Compensate for the change in AnchorX and AnchorY.
            button.TranslationX -= button.Width - button.Height;
            button.TranslationY += button.Width + button.Height;

            // Fall over.
            await button.RotateTo(180, 1000, Easing.BounceOut);

            // Fade out while ascending to the top of the screen.
            await Task.WhenAll
                (
                    button.FadeTo(0, 4000),
                    button.TranslateTo(0, -Height, 5000, Easing.CubicIn)
                );

            // After three seconds, return the Button to normal.
            await Task.Delay(3000);
            button.TranslationX = 0;
            button.TranslationY = 0;
            button.Rotation = 0;
            button.Opacity = 1;
        }
    }
}
