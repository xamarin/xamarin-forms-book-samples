using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ViewGalleryInst
{
    public partial class ActivityIndicatorPage : ContentPage
    {
        public ActivityIndicatorPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            activityIndicator.IsRunning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            activityIndicator.IsRunning = false;
        }
    }
}
