using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace SpringSlidingEntrance
{
    public partial class SpringSlidingEntrancePage : ContentPage
    {
        public SpringSlidingEntrancePage()
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
                await Task.WhenAny(view.TranslateXTo(0, 1000, Easing.SpringOut),
                                   Task.Delay(100));
            }
        }
    }
}
