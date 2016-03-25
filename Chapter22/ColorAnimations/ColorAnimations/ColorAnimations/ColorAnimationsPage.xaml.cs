using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace ColorAnimations
{
    public partial class ColorAnimationsPage : ContentPage
    {
        public ColorAnimationsPage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        async void AnimationLoop()
        {
            while (true)
            {
                Action<Color> textCallback = color => label.TextColor = color;
                Action<Color> backCallback = color => label.BackgroundColor = color;

                await Task.WhenAll(
                        label.RgbColorAnimation(Color.White, Color.Black, textCallback, 1000),
                        label.HslColorAnimation(Color.Black, Color.White, backCallback, 1000));

                await Task.WhenAll(
                        label.RgbColorAnimation(Color.Black, Color.White, textCallback, 1000),
                        label.HslColorAnimation(Color.White, Color.Black, backCallback, 1000));
            }
        }

        async void OnRainbowBackgroundButtonClicked(object sender, EventArgs args)
        {
            // Animate from Red to Red.
            await this.HslColorAnimation(Color.FromHsla(0, 1, 0.5),
                                         Color.FromHsla(1, 1, 0.5),
                                         color => BackgroundColor = color,
                                         10000);

            BackgroundColor = Color.Default;
        }

        async void OnBoxViewColorButtonClicked(object sender, EventArgs args)
        {
            Action<Color> callback1 = color => boxView1.Color = color;
            Action<Color> callback2 = color => boxView2.Color = color;

            await Task.WhenAll(boxView1.RgbColorAnimation(Color.Blue, Color.Red, callback1, 2000),
                               boxView2.HslColorAnimation(Color.Blue, Color.Red, callback2, 2000));

            await Task.WhenAll(boxView1.RgbColorAnimation(Color.Red, Color.Blue, callback1, 2000),
                               boxView2.HslColorAnimation(Color.Red, Color.Blue, callback2, 2000));

        }
    }
}
