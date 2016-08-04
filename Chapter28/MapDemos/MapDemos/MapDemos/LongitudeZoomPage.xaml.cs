using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.FormsBook.Toolkit.Maps;

namespace MapDemos
{
    public partial class LongitudeZoomPage : ContentPage
    {
        const double InitialLongitudeSpan = 48;
        const double InitialZoom = 0;

        public LongitudeZoomPage()
        {
            InitializeComponent();

            map.MoveToRegion(new MapSpan(new Position(38.62452, -90.18471), 
                                         0, InitialLongitudeSpan));
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            Position center = map.VisibleRegion.Center;
            double longitudeSpan = InitialLongitudeSpan * Math.Pow(2, InitialZoom - args.NewValue);
            map.MoveToRegion(new MapSpan(center, 0, longitudeSpan));
        }
    }
}
