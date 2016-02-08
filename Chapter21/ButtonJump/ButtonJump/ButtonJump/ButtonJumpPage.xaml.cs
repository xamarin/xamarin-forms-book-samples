using System;
using Xamarin.Forms;

namespace ButtonJump
{
    public partial class ButtonJumpPage : ContentPage
    {
        Random random = new Random();

        public ButtonJumpPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            View container = (View)button.Parent;

            button.TranslationX = (random.NextDouble() - 0.5) * (container.Width - button.Width);
            button.TranslationY = (random.NextDouble() - 0.5) * (container.Height - button.Height);
        }
    }
}
