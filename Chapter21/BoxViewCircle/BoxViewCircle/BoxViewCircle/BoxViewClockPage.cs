using System;
using Xamarin.Forms;

namespace BoxViewCircle
{
    public class BoxViewClockPage : ContentPage
    {
        const int COUNT = 64;
        const double THICKNESS = 4;

        public BoxViewClockPage()
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            Content = absoluteLayout;

            for (int index = 0; index < COUNT; index++)
            {
                absoluteLayout.Children.Add(new BoxView 
                    {
                        Color = Color.Accent,
                    });
            }

            absoluteLayout.SizeChanged += (sender, args) =>
                {
                    Point center = new Point(absoluteLayout.Width / 2, absoluteLayout.Height / 2);
                    double radius = Math.Min(absoluteLayout.Width, absoluteLayout.Height) / 2;
                    double circumference = 2 * Math.PI * radius;
                    double length = circumference / COUNT;

                    for (int index = 0; index < absoluteLayout.Children.Count; index++)
                    {
                        BoxView boxView = (BoxView)absoluteLayout.Children[index];

                        // Position every BoxView at the top.
                        AbsoluteLayout.SetLayoutBounds(boxView,
                            new Rectangle(center.X - length / 2, 
                                            center.Y - radius, 
                                            length, 
                                            THICKNESS));

                        // Set the AnchorX and AnchorY properties so rotation is 
                        //      around the center of the AbsoluteLayout.
                        boxView.AnchorX = 0.5;
                        boxView.AnchorY = radius / THICKNESS;

                        // Set a unique Rotation for each BoxView.
                        boxView.Rotation = index * 360.0 / COUNT;
                    }
                };
        }
    }
}
