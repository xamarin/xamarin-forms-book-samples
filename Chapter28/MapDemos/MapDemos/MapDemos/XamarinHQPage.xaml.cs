using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.FormsBook.Toolkit.Maps;

namespace MapDemos
{
    public partial class XamarinHQPage : ContentPage
    {
        bool stopTimer;

        public XamarinHQPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                if (stopTimer)
                    return false;

                MapSpan mapSpan = map.VisibleRegion;

                if (mapSpan != null)
                {
                    center.Text = mapSpan.Center.ToString("S0");
                    span.Text = new Position(mapSpan.LatitudeDegrees,
                                             mapSpan.LongitudeDegrees).ToString("S0");
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
