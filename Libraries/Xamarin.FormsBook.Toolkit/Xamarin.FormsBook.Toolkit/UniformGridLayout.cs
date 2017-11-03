using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class UniformGridLayout : WrapLayout
    {
        public static readonly BindableProperty AspectRatioProperty =
            BindableProperty.Create(
                "AspectRatio",
                typeof(AspectRatio),
                typeof(UniformGridLayout),
                AspectRatio.Auto,
                propertyChanged: (bindable, oldvalue, newvalue) =>
                {
                    ((UniformGridLayout)bindable).InvalidateLayout();
                });

        public AspectRatio AspectRatio
        {
            set { SetValue(AspectRatioProperty, value); }
            get { return (AspectRatio)GetValue(AspectRatioProperty); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, 
                                                 double heightConstraint)
        {
            if (Double.IsInfinity(widthConstraint) || Double.IsInfinity(heightConstraint))
                throw new InvalidOperationException(
                    "UniformGridLayout cannot be used with unconstrained dimensions.");

            // Just check to see if there aren't any visible children.
            int childCount = 0;

            foreach (View view in Children)
                childCount += view.IsVisible ? 1 : 0;

            if (childCount == 0)
                return new SizeRequest();

            // Then request the entire (non-infinite) size.
            return new SizeRequest(new Size(widthConstraint, heightConstraint));
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            int childCount = 0;

            foreach (View view in Children)
                childCount += view.IsVisible ? 1 : 0;

            if (childCount == 0)
                return;

            double childAspect = AspectRatio.Value;

            // If AspectRatio is Auto, calculate an average aspect ratio
            if (AspectRatio.IsAuto)
            {
                int nonZeroChildCount = 0;
                double accumAspectRatio = 0;

                foreach (View view in Children)
                {
                    if (view.IsVisible)
                    {
                        SizeRequest sizeRequest = view.Measure(Double.PositiveInfinity, 
                                                               Double.PositiveInfinity,
                                                               MeasureFlags.IncludeMargins);

                        if (sizeRequest.Request.Width > 0 && sizeRequest.Request.Height > 0)
                        {
                            nonZeroChildCount++;
                            accumAspectRatio += sizeRequest.Request.Width / 
                                                    sizeRequest.Request.Height;
                        }
                    }
                }

                if (nonZeroChildCount > 0)
                {
                    childAspect = accumAspectRatio / nonZeroChildCount;
                }
                else
                {
                    childAspect = 1;
                }
            }

            int bestRowsCount = 0;
            int bestColsCount = 0;
            double bestUsage = 0;
            double bestChildWidth = 0;
            double bestChildHeight = 0;

            // Test various possibilities of the number of columns.
            for (int colsCount = 1; colsCount <= childCount; colsCount++)
            {
                // Find the number of rows for that many columns.
                int rowsCount = (int)Math.Ceiling((double)childCount / colsCount);

                // Determine if we have more rows or columns than we need.
                if ((rowsCount - 1) * colsCount >= childCount ||
                    rowsCount * (colsCount - 1) >= childCount)
                {
                    continue;
                }

                // Get the aspect ratio of the resultant cells.
                double cellWidth = (width - ColumnSpacing * (colsCount - 1)) / colsCount;
                double cellHeight = (height - RowSpacing * (rowsCount - 1)) / rowsCount;
                double cellAspect = cellWidth / cellHeight;
                double usage = 0;

                // Compare with the average aspect ratio of the child.
                if (cellAspect > childAspect)
                {
                    usage = childAspect / cellAspect;
                }
                else
                {
                    usage = cellAspect / childAspect;
                }

                // If we're using more space, save the numbers.
                if (usage > bestUsage)
                {
                    bestRowsCount = rowsCount;
                    bestColsCount = colsCount;
                    bestUsage = usage;
                    bestChildWidth = cellWidth;
                    bestChildHeight = cellHeight;
                }
            }

            int colIndex = 0;
            int rowIndex = 0;
            double xChild = x;
            double yChild = y;

            foreach (View view in Children)
            {
                // Position and size the child.
                LayoutChildIntoBoundingRegion(view, 
                    new Rectangle(xChild, yChild, bestChildWidth, bestChildHeight));

                // Increment the coordinates and indices.
                if (Orientation == WrapOrientation.HorizontalThenVertical)
                {
                    xChild += bestChildWidth + ColumnSpacing;

                    if (++colIndex == bestColsCount)
                    {
                        colIndex = 0;
                        xChild = x;
                        yChild += bestChildHeight + RowSpacing;
                    }
                }
                else // Orientation == WrapOrientation.VerticalThenHorizontal
                {
                    yChild += bestChildHeight + RowSpacing;

                    if (++rowIndex == bestRowsCount)
                    {
                        rowIndex = 0;
                        xChild += bestChildWidth + ColumnSpacing;
                        yChild = y;
                    }
                }
            }
        }
    }
}
