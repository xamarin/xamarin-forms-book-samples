using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Platform;

namespace WhereAmI
{
    public partial class WhereAmIPage : ContentPage
    {
        GeographicLocation location;

        public WhereAmIPage()
        {
            InitializeComponent();

            ILocationTracker locationTracker = DependencyService.Get<ILocationTracker>();
            locationTracker.LocationChanged += OnLocationTrackerLocationChanged;
            locationTracker.StartTracking();
        }

        void OnLocationTrackerLocationChanged(object sender, GeographicLocation args)
        {
            locationLabel.Text = args.ToString();
            timestampLabel.Text = DateTime.Now.ToString("h:mm:ss.FFF");

            // Update dot on map.
            location = args;
            UpdateLocationDot(args);
        }

        void OnAbsoluteLayoutSizeChanged(object sender, EventArgs args)
        {
            // Update dot on map.
            UpdateLocationDot(location);
        }

        void UpdateLocationDot(GeographicLocation location)
        {
            double x = (location.Longitude + 180) * absLayout.Width / 360;
            double y = (90 - location.Latitude) * absLayout.Height / 180;

            AbsoluteLayout.SetLayoutBounds(ellipse, 
                new Rectangle(x, y, AbsoluteLayout.AutoSize, 
                                    AbsoluteLayout.AutoSize));
        }
    }
}
