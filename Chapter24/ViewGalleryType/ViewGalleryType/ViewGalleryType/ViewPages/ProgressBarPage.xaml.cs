using System;
using Xamarin.Forms;

namespace ViewGalleryType
{
    public partial class ProgressBarPage : ContentPage
    {
        bool pageIsVisible;
        DateTime startDateTime;

        public ProgressBarPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pageIsVisible = true;
            startDateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1.0 / 60), OnTimerCallback);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pageIsVisible = false;
        }

        bool OnTimerCallback()
        {
            progressBar.Progress = (DateTime.Now - startDateTime).TotalSeconds / 3 % 1;
            return pageIsVisible;
        }
    }
}
