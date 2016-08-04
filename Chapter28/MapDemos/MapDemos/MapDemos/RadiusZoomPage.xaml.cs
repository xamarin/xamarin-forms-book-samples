using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.FormsBook.Toolkit.Maps;

namespace MapDemos
{
    public partial class RadiusZoomPage : ContentPage
    {
        const double InitialRadius = 1;     // kilometer
        const double InitialZoom = 11;

        public RadiusZoomPage()
        {
            InitializeComponent();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(38.62452, -90.18471),
                                                         Distance.FromKilometers(InitialRadius)));
            slider.Value = InitialZoom;
            slider.ValueChanged += OnSliderValueChanged;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            // Watch out for Android event firing!
            if (map.VisibleRegion == null)
                return;

            Position center = map.VisibleRegion.Center;
            double radius = InitialRadius * Math.Pow(2, InitialZoom - args.NewValue);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(center, Distance.FromKilometers(radius)));
        }
    }
}
