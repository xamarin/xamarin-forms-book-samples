using System;
using Xamarin.Forms;

namespace TextFade
{
    public partial class TextFadePage : ContentPage
    {
        public TextFadePage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            AbsoluteLayout.SetLayoutBounds(label1,
                new Rectangle(args.NewValue, 0.5, AbsoluteLayout.AutoSize, 
                                                  AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutBounds(label2,
                new Rectangle(args.NewValue, 0.5, AbsoluteLayout.AutoSize, 
                                                  AbsoluteLayout.AutoSize));

            label1.Opacity = 1 - args.NewValue;
            label2.Opacity = args.NewValue;
        }
    }
}
