using System;
using Xamarin.Forms;

namespace SwitchDemo
{
    public partial class SwitchDemoPage : ContentPage
    {
        public SwitchDemoPage()
        {
            InitializeComponent();
        }

        void OnItalicSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        void OnBoldSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }
}
