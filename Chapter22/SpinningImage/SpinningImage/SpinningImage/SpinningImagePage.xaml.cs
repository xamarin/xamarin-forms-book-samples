using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpinningImage
{
    public partial class SpinningImagePage : ContentPage
    {
        public SpinningImagePage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        async void AnimationLoop()
        {
            uint duration = 5 * 60 * 1000;  // 5 minutes

            while (true)
            {
                await Task.WhenAll(
                    image.RotateTo(307 * 360, duration),
                    image.RotateXTo(251 * 360, duration),
                    image.RotateYTo(199 * 360, duration));

                image.Rotation = 0;
                image.RotationX = 0;
                image.RotationY = 0;
            }
        }
    }
}
