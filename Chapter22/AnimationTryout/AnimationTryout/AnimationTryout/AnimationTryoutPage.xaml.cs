using System;
using Xamarin.Forms;

namespace AnimationTryout
{
    public partial class AnimationTryoutPage : ContentPage
    {
        public AnimationTryoutPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            button.RotateTo(360);
        }
    }
}
