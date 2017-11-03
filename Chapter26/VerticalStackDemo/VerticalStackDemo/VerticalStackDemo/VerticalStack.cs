using System;
using Xamarin.Forms;

namespace VerticalStackDemo
{ 
    public class VerticalStack : Layout<View>
    {
        protected override SizeRequest OnMeasure(double widthConstraint, 
                                                 double heightConstraint)
        {
            Size reqSize = new Size();
            Size minSize = new Size();

            // Enumerate through all the children.
            foreach (View child in Children)
            {
                // Skip the invisible children.
                if (!child.IsVisible)
                    continue;

                // Get the child's requested size.
                SizeRequest childSizeRequest = child.Measure(widthConstraint, 
                                                             Double.PositiveInfinity,
                                                             MeasureFlags.IncludeMargins);

                // Find the maximum width and accumulate the height.
                reqSize.Width = Math.Max(reqSize.Width, childSizeRequest.Request.Width);
                reqSize.Height += childSizeRequest.Request.Height;

                // Do the same for the minimum size request.
                minSize.Width = Math.Max(minSize.Width, childSizeRequest.Minimum.Width);
                minSize.Height += childSizeRequest.Minimum.Height;
            }
            return new SizeRequest(reqSize, minSize);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            // Enumerate through all the children.
            foreach (View child in Children)
            {
                // Skip the invisible children.
                if (!child.IsVisible)
                    continue;

                // Get the child's requested size.
                SizeRequest childSizeRequest = child.Measure(width, Double.PositiveInfinity,
                                                             MeasureFlags.IncludeMargins);

                // Initialize child position and size.
                double xChild = x;
                double yChild = y;
                double childWidth = childSizeRequest.Request.Width;
                double childHeight = childSizeRequest.Request.Height;

                // Adjust position and size based on HorizontalOptions.
                switch (child.HorizontalOptions.Alignment)
                {
                    case LayoutAlignment.Start:
                        break;

                    case LayoutAlignment.Center:
                        xChild += (width - childWidth) / 2;
                        break;

                    case LayoutAlignment.End:
                        xChild += (width - childWidth);
                        break;

                    case LayoutAlignment.Fill:
                        childWidth = width;
                        break;
                }

                // Layout the child.
                child.Layout(new Rectangle(xChild, yChild, childWidth, childHeight));

                // Calculate the next child's vertical position.
                y += childHeight;
            }
        }
    }
}
