using System;
using Xamarin.Forms;

namespace NothingAlert
{
    public partial class NothingAlertPage : ContentPage
    {
        public NothingAlertPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            label.Text = "Displaying alert box";
            await DisplayAlert("Simple Alert", "Click 'dismiss' to dismiss", "dismiss");
            label.Text = "Alert has been dismissed";
        }
    }
}
