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

            if (Device.OS != TargetPlatform.Android)
            {
                locationTracker = DependencyService.Get<ILocationTracker>();
                locationTracker.LocationChanged += OnLocationTracker;
            }
        }

        void OnLocationTracker(object sender, GeographicLocation args)
        {
            position = new Position(args.Latitude, args.Longitude);
            myLocationButton.IsVisible = Device.OS != TargetPlatform.Android;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.OS != TargetPlatform.Android)
            {
                locationTracker.StartTracking();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (Device.OS != TargetPlatform.Android)
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
