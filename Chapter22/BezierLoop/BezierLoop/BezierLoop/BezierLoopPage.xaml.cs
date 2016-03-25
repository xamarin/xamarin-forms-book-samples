using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace BezierLoop
{
    public partial class BezierLoopPage : ContentPage
    {
        public BezierLoopPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            Layout parent = (Layout)button.Parent;

            // Center of Button in upper-left corner.
            Point point0 = new Point(button.Width / 2, button.Height / 2);

            // Lower-right corner of page.
            Point point1 = new Point(parent.Width, parent.Height);

            // Lower-left corner of page.
            Point point2 = new Point(0, parent.Height);

            // Center of Button in upper-right corner.
            Point point3 = new Point(parent.Width - button.Width / 2, button.Height / 2);

            // Initial angle of Bezier curve (vector from Point0 to Point1).
            double angle = 180 / Math.PI * Math.Atan2(point1.Y - point0.Y,
                                                      point1.X - point0.X);

            await button.RotateTo(angle, 1000, Easing.SinIn);

            await button.BezierPathTo(point1, point2, point3, 5000, 
                                      BezierTangent.Normal, Easing.SinOut);

            await button.BezierPathTo(point2, point1, point0, 5000, 
                                      BezierTangent.Reversed, Easing.SinIn);

            await button.RotateTo(0, 1000, Easing.SinOut);
        }
    }
}
