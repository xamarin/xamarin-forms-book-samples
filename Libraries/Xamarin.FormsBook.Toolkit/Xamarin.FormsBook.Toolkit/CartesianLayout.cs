using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class CartesianLayout : Layout<BoxView>
    {
        public static readonly BindableProperty Point1Property =
            BindableProperty.CreateAttached("Point1",
                                            typeof(Point),
                                            typeof(CartesianLayout),
                                            new Point());

        public static readonly BindableProperty Point2Property =
            BindableProperty.CreateAttached("Point2",
                                            typeof(Point),
                                            typeof(CartesianLayout),
                                            new Point());

        public static readonly BindableProperty ThicknessProperty =
            BindableProperty.CreateAttached("Thickness",
                                            typeof(Double),
                                            typeof(CartesianLayout),
                                            1.0);       // must be explicitly Double!

        public static void SetPoint1(BindableObject bindable, Point point)
        {
            bindable.SetValue(Point1Property, point);
        }

        public static Point GetPoint1(BindableObject bindable)
        {
            return (Point)bindable.GetValue(Point1Property);
        }

        public static void SetPoint2(BindableObject bindable, Point point)
        {
            bindable.SetValue(Point2Property, point);
        }

        public static Point GetPoint2(BindableObject bindable)
        {
            return (Point)bindable.GetValue(Point2Property);
        }

        public static void SetThickness(BindableObject bindable, double thickness)
        {
            bindable.SetValue(ThicknessProperty, thickness);
        }

        public static double GetThickness(BindableObject bindable)
        {
            return (double)bindable.GetValue(ThicknessProperty);
        }

        // Monitor PropertyChanged events for items in the Children collection.
        protected override void OnAdded(BoxView boxView)
        {
            base.OnAdded(boxView);
            boxView.PropertyChanged += OnChildPropertyChanged;
        }

        protected override void OnRemoved(BoxView boxView)
        {
            base.OnRemoved(boxView);
            boxView.PropertyChanged -= OnChildPropertyChanged;
        }

        void OnChildPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == Point1Property.PropertyName ||
                args.PropertyName == Point2Property.PropertyName ||
                args.PropertyName == ThicknessProperty.PropertyName)
            {
                InvalidateLayout();
            }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, 
                                                 double heightConstraint)
        {
            if (Double.IsInfinity(widthConstraint) && Double.IsInfinity(heightConstraint))
                throw new InvalidOperationException(
                    "CartesianLayout requires at least one dimension to be constrained.");

            // Make it square!
            double minimum = Math.Min(widthConstraint, heightConstraint);
            return new SizeRequest(new Size(minimum, minimum));
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            foreach (View child in Children)
            {
                if (!child.IsVisible)
                    continue;

                double angle;
                Rectangle bounds = GetChildBounds(child, x, y, width, height, out angle);

                // Lay out the child.
                child.Layout(bounds);

                // Rotate the child.
                child.Rotation = angle;
            }
        }

        protected Rectangle GetChildBounds(View child, 
                                           double x, double y, double width, double height, 
                                           out double angle)
        {
            // Get coordinate system information.
            Point coordCenter = new Point(x + width / 2, y + height / 2);
            double unitLength = Math.Min(width, height) / 2;

            // Get child information.
            Point point1 = GetPoint1(child);
            Point point2 = GetPoint2(child);
            double thickness = GetThickness(child);
            double length = unitLength * Math.Sqrt(Math.Pow(point2.X - point1.X, 2) +
                                                   Math.Pow(point2.Y - point1.Y, 2));

            // Calculate child bounds.
            Point centerChild = new Point((point1.X + point2.X) / 2,
                                          (point1.Y + point2.Y) / 2);

            double xChild = coordCenter.X + unitLength * centerChild.X - length / 2;
            double yChild = coordCenter.Y - unitLength * centerChild.Y - thickness / 2;
            Rectangle bounds = new Rectangle(xChild, yChild, length, thickness);
            angle = 180 / Math.PI * Math.Atan2(point1.Y - point2.Y,
                                               point2.X - point1.X);

            return bounds;
        }
    }
}
