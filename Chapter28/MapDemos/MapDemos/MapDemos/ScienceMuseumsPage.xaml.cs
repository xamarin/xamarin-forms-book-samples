using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapDemos
{
    public partial class ScienceMuseumsPage : ContentPage
    {
        // Load in the data.
        Locations locations = Locations.Load("MapDemos.Data.ScienceMuseums.xml");

        public ScienceMuseumsPage()
        {
            InitializeComponent();

            // Center the U.S. in the map
            map.MoveToRegion(new MapSpan(new Position(45, -110), 50, 100));

            // Create the pins
            foreach (Site site in locations.Sites)
            {
                Pin pin = new Pin
                {
                    BindingContext = site,
                    Label = site.Name,
                    Position = new Position(site.Latitude, site.Longitude),
                    Address = site.Address
                };

                pin.Clicked += OnPinClicked;
                map.Pins.Add(pin);
            }
        }

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
