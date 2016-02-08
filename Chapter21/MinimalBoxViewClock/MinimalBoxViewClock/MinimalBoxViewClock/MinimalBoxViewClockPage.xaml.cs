using System;
using Xamarin.Forms;

namespace MinimalBoxViewClock
{
    public partial class MinimalBoxViewClockPage : ContentPage
    {
        public MinimalBoxViewClockPage()
        {
            InitializeComponent();
        }

        void OnAbsoluteLayoutSizeChanged(object sender, EventArgs args)
        {
            AbsoluteLayout absoluteLayout = (AbsoluteLayout)sender;

            // Calculate a center and radius for the clock.
            Point center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
            double radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;

            // Position all hands pointing up from center.
            AbsoluteLayout.SetLayoutBounds(hourHand, 
                new Rectangle(center.X - radius * 0.05, 
                              center.Y - radius * 0.6, 
                              radius * 0.10, radius * 0.6));

            AbsoluteLayout.SetLayoutBounds(minuteHand,
                new Rectangle(center.X - radius * 0.025, 
                              center.Y - radius * 0.7, 
                              radius * 0.05, radius * 0.7));

            AbsoluteLayout.SetLayoutBounds(secondHand,
                new Rectangle(center.X - radius * 0.01, 
                              center.Y - radius * 0.9,
                              radius * 0.02, radius * 0.9));

            // Set the anchor to bottom center of BoxView.
            hourHand.AnchorY = 1;
            minuteHand.AnchorY = 1;
            secondHand.AnchorY = 1;
        }
    }
}
