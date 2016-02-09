using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CopterAnimation
{
    public partial class CopterAnimationPage : ContentPage
    {
        public CopterAnimationPage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        async void AnimationLoop()
        {
            while (true)
            {
                revolveTarget.Rotation = 0;
                copterView.Rotation = 0;

                await Task.WhenAll(revolveTarget.RotateTo(360, 5000),
                                   copterView.RotateTo(360 * 5, 5000));
            }
        }
    }
}
