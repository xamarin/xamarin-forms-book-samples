using System;
using Xamarin.Forms;

namespace SimpleOverlay
{
    public partial class SimpleOverlayPage : ContentPage
    {
        public SimpleOverlayPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            // Show overlay with ProgressBar.
            overlay.IsVisible = true;

            TimeSpan duration = TimeSpan.FromSeconds(5);
            DateTime startTime = DateTime.Now;

            // Start timer.
            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                {
                    double progress = (DateTime.Now - startTime).TotalMilliseconds / 
                                      duration.TotalMilliseconds;
                    progressBar.Progress = progress;
                    bool continueTimer = progress < 1;

                    if (!continueTimer)
                    {
                        // Hide overlay.
                        overlay.IsVisible = false;
                    }
                    return continueTimer;
                });
        }
    }
}
