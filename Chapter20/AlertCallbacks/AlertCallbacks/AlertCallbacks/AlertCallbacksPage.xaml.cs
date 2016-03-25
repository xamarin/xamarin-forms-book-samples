using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlertCallbacks
{
    public partial class AlertCallbacksPage : ContentPage
    {
        bool result;

        public AlertCallbacksPage()
        {
            InitializeComponent();
        }
        void OnButtonClicked(object sender, EventArgs args)
        {
            Task<bool> task = DisplayAlert("Simple Alert", "Decide on an option",
                                           "yes or ok", "no or cancel");
            task.ContinueWith(AlertDismissedCallback);
            label.Text = "Alert is currently displayed";
        }

        void AlertDismissedCallback(Task<bool> task)
        {
            result = task.Result;
            Device.BeginInvokeOnMainThread(DisplayResultCallback);
        }

        void DisplayResultCallback()
        {
            label.Text = String.Format("Alert {0} button was pressed",
                                       result ? "OK" : "Cancel");
        }
    }
}
