using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.FormsBook.Platform;
using Xamarin.FormsBook.Toolkit.Maps;

namespace MapDemos
{
    public partial class LocalMuseumsPage : ContentPage
    {
        const int NUM_VISIBLE = 10;
        static readonly Distance RADIUS = Distance.FromMiles(100);

        Locations locations = Locations.Load("MapDemos.Data.ScienceMuseums.xml");
        ILocationTracker locationTracker;
        Position userPosition;
        Position mapCenter;

        public LocalMuseumsPage()
        {
            InitializeComponent();

            // Center the map on the 48-states geographic center.
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(39.828175, -98.579500), RADIUS));

            // Track user's location.
            locationTracker = DependencyService.Get<ILocationTracker>();
            locationTracker.LocationChanged += OnLocationTracker;

            // Track map center.
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerCallback);
        }

        // Location tracking and go-to location methods.
        void OnLocationTracker(object sender, GeographicLocation args)
        {
            userPosition = new Position(args.Latitude, args.Longitude);

            // Determine distances between the user and museums.
            foreach (Site site in locations.Sites)
            {
                Position sitePosition = new Position(site.Latitude, site.Longitude);
                site.DistanceToUser = sitePosition.DistanceTo(userPosition).Miles;
            }

            myLocationButton.IsVisible = Device.RuntimePlatform != Device.Android;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            locationTracker.StartTracking();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locationTracker.PauseTracking();
        }

        void OnLocationButtonClicked(object sender, EventArgs args)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(userPosition, RADIUS));
        }

        // Track the map center to create and detach pins.
        bool OnTimerCallback()
        {
            if (map.VisibleRegion == null)
                return true;

            Position mapCenter = map.VisibleRegion.Center;

            if (this.mapCenter != mapCenter)
            {
                this.mapCenter = mapCenter;

                // Loop through sites and calculate distance from map center.
                foreach (Site site in locations.Sites)
                {
                    Position sitePosition = new Position(site.Latitude, site.Longitude);
                    site.DistanceToCenter = sitePosition.DistanceTo(mapCenter).Miles;
                }

                // Sort by distance.
                locations.Sites.Sort((site1, site2) => 
                    site1.DistanceToCenter.CompareTo(site2.DistanceToCenter));

                // Remove pins not in the top 10.
                List<Pin> removeList = new List<Pin>();

                foreach (Pin pin in map.Pins)
                {
                    bool match = false;

                    for (int i = 0; i < NUM_VISIBLE; i++)
                    {
                        match |= pin.BindingContext == locations.Sites[i];
                    }

                    if (!match)
                    {
                        removeList.Add(pin);
                    }
                }

                foreach (Pin pin in removeList)
                {
                    pin.Clicked -= OnPinClicked;
                    map.Pins.Remove(pin);
                }

                // Add pins from the top 10.
                for (int i = 0; i < NUM_VISIBLE; i++)
                {
                    Site site = locations.Sites[i];
                    bool match = false;

                    foreach (Pin pin in map.Pins)
                    {
                        match |= pin.BindingContext == site;
                    }

                    if (!match)
                    {
                        Pin newPin = new Pin
                        {
                            BindingContext = site,
                            Label = site.Name,
                            Position = new Position(site.Latitude, site.Longitude),
                            Address = site.Address
                        };

                        newPin.Clicked += OnPinClicked;
                        map.Pins.Add(newPin);
                    }
                }
            }
            return true;
        }

        // Event handlers from ScienceMuseumsPage.
        void OnPinClicked(object sender, EventArgs args)
        {
            absLayout.BackgroundColor = new Color(0, 0, 0, 0.5);
            absLayout.InputTransparent = false;

            popup.BindingContext = (sender as Pin).BindingContext;
            popup.IsVisible = true;
        }

        void OnAbsoluteLayoutTapped(object sender, EventArgs args)
        {
            popup.IsVisible = false;
            popup.BindingContext = null;
            absLayout.InputTransparent = true;
            absLayout.BackgroundColor = Color.Transparent;
        }

        async void OnLinkLabelTapped(object sender, EventArgs args)
        {
            Site site = ((sender as Label).BindingContext as Site);

            await Navigation.PushAsync(new ContentPage
            {
                Title = site.Name,
                Content = new WebView
                {
                    Source = site.Website
                }
            });
        }
    }
}
