using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapDemos
{
    public partial class MapCoordinatesPage : ContentPage
    {
        bool stopTimer;

        public MapCoordinatesPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                if (stopTimer)
                    return false;

                MapSpan mapSpan = map.VisibleRegion;

                if (mapSpan != null)
                {
                    latitude.Text = mapSpan.Center.Latitude.ToString("F4") + '°';
                    longitude.Text = mapSpan.Center.Longitude.ToString("F4") + '°';
                    latitudeSpan.Text = mapSpan.LatitudeDegrees.ToString("F6") + '°';
                    longitudeSpan.Text = mapSpan.LongitudeDegrees.ToString("F6") + '°';
                    radius.Text = mapSpan.Radius.Kilometers.ToString("F1") + " km / " +
                                  mapSpan.Radius.Miles.ToString("F1") + " mi";
                }
                return true;
            });
        }

        protected override void OnDisappearing()
        {
            stopTimer = true;
            base.OnDisappearing();
        }
    }
}
