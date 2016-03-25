using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace FormattedTextToggle
{
    public partial class FormattedTextTogglePage : ContentPage
    {
        public FormattedTextTogglePage()
        {
            InitializeComponent();
        }

        void OnBehaviorPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "IsToggled")
            {
                eventLabel.Text = "IsToggled = " + ((ToggleBehavior)sender).IsToggled;
                eventLabel.Opacity = 1;
                eventLabel.FadeTo(0, 1000);
            }
        }
    }
}
