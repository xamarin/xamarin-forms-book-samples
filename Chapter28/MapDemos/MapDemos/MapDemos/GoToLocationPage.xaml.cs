using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.FormsBook.Platform;

namespace MapDemos
{
    public partial class GoToLocationPage : ContentPage
    {
        ILocationTracker locationTracker;
        Position position;

        public GoToLocationPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform != Device.Android)
            {
                locationTracker = DependencyService.Get<ILocationTracker>();
                locationTracker.LocationChanged += OnLocationTracker;
            }
        }

        void OnLocationTracker(object sender, GeographicLocation args)
        {
            position = new Position(args.Latitude, args.Longitude);
            myLocationButton.IsVisible = Device.RuntimePlatform != Device.Android;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.RuntimePlatform != Device.Android)
            {
                locationTracker.StartTracking();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (Device.RuntimePlatform != Device.Android)
            {
                locationTracker.PauseTracking();
            }
        }

        void OnLocationButtonClicked(object sender, EventArgs args)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(2)));
        }
    }
}
