using System;
using Windows.Devices.Geolocation;

#if WINDOWS_UWP
using Windows.Foundation;
#endif

using Xamarin.Forms;

[assembly: Dependency(typeof(Xamarin.FormsBook.Platform.WinRT.LocationTracker))]

namespace Xamarin.FormsBook.Platform.WinRT
{
    public class LocationTracker : ILocationTracker
    {
        Geolocator geolocator;
#if WINDOWS_UWP
        bool isTracking;
#endif
        public LocationTracker()
        {
            geolocator = new Geolocator();
            geolocator.ReportInterval = 1000;
        }

        public event EventHandler<GeographicLocation> LocationChanged;

        public void StartTracking()
        {
#if WINDOWS_UWP
            IAsyncOperation<GeolocationAccessStatus> task = Geolocator.RequestAccessAsync();

            task.Completed = (asyncop, status) =>
            {
                GeolocationAccessStatus accessStatus = asyncop.GetResults();
                if (accessStatus == GeolocationAccessStatus.Allowed)
                {
                    geolocator.PositionChanged += OnGeolocatorPositionChanged;
                    isTracking = true;
                }
            };
#else
           geolocator.PositionChanged += OnGeolocatorPositionChanged;
#endif
        }

        public void PauseTracking()
        {
#if WINDOWS_UWP
            if (isTracking)
            {
                geolocator.PositionChanged -= OnGeolocatorPositionChanged;
            }
#else
            geolocator.PositionChanged -= OnGeolocatorPositionChanged;
#endif
        }

        void OnGeolocatorPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            BasicGeoposition coordinate = args.Position.Coordinate.Point.Position;

            Device.BeginInvokeOnMainThread(() =>
            {
                LocationChanged?.Invoke(this, new GeographicLocation(coordinate.Latitude,
                                                                     coordinate.Longitude));
            });
        }
    }
}