using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlidingEntrance
{
    public partial class SlidingEntrancePage : ContentPage
    {
        public SlidingEntrancePage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            double offset = 1000;

            foreach (View view in stackLayout.Children)
            {
                view.TranslationX = offset;
                offset *= -1;
            }

            foreach (View view in stackLayout.Children)
            {
                await Task.WhenAny(view.TranslateTo(0, 0, 1000, Easing.SpringOut),
                                   Task.Delay(100));
            }
        }
    }
}
