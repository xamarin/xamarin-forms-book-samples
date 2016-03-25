using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlertLambdas
{
    public partial class AlertLambdasPage : ContentPage
    {
        public AlertLambdasPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Task<bool> task = DisplayAlert("Simple Alert", "Decide on an option",
                                           "yes or ok", "no or cancel");
            task.ContinueWith((Task<bool> taskResult) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                        {
                            label.Text = String.Format("Alert {0} button was pressed",
                                                       taskResult.Result ? "OK" : "Cancel");
                        });
                });
            label.Text = "Alert is currently displayed";
        }
    }
}
