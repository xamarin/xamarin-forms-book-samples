using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FadingTextAnimation
{
    public partial class FadingTextAnimationPage : ContentPage
    {
        public FadingTextAnimationPage()
        {
            InitializeComponent();

            // Start the animation going.
            AnimationLoop();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            if (Width > 0)
            {
                double fontSize = 0.3 * Width;
                label1.FontSize = fontSize;
                label2.FontSize = fontSize;
            }
        }

        async void AnimationLoop()
        {
            while (true)
            {
                await Task.WhenAll(label1.FadeTo(0, 1000),
                                   label2.FadeTo(1, 1000));

                await Task.WhenAll(label1.FadeTo(1, 1000),
                                   label2.FadeTo(0, 1000));
            }
        }
    }
}
