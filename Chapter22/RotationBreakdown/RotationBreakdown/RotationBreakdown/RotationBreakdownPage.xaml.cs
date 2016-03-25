using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RotationBreakdown
{
    public partial class RotationBreakdownPage : ContentPage
    {
        public RotationBreakdownPage()
        {
            InitializeComponent();

            AnimationLoop();
        }

        async void AnimationLoop()
        {
            const int increment = 36000;

            while (true)
            {
                overBoxView.Rotation = 0;

                await Task.WhenAll(underBoxView.RelRotateTo(increment),
                                   overBoxView.RotateTo(increment));

                label.Text = String.Format("Rotation = {0:E}", underBoxView.Rotation);
            }
        }
    }
}
