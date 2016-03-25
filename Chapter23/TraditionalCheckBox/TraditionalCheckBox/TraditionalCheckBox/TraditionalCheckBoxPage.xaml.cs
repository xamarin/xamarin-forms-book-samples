using System;
using Xamarin.Forms;

namespace TraditionalCheckBox
{
    public partial class TraditionalCheckBoxPage : ContentPage
    {
        public TraditionalCheckBoxPage()
        {
            InitializeComponent();
        }

        void OnToggleBaseToggled(object sender, ToggledEventArgs args)
        {
            eventLabel.Text = "IsToggled = " + args.Value;
            eventLabel.Opacity = 1;
            eventLabel.FadeTo(0, 1000);
        }
    }
}
