using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class WrapLayout : Layout<View>
    {
        struct LayoutInfo
        {
            public LayoutInfo(int visibleChildCount, Size cellSize, int rows, int cols) : this()
            {
                VisibleChildCount = visibleChildCount;
                CellSize = cellSize;
                Rows = rows;
                Cols = cols;
            }

            public int VisibleChildCount { private set; get; }

            public Size CellSize { private set; get; }

            public int Rows { private set; get; }

            public int Cols { private set; get; }
        }

        Dictionary<Size, LayoutInfo> layoutInfoCache = new Dictionary<Size, LayoutInfo>();

        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(
                "Orientation",
                typeof(WrapOrientation),
                typeof(WrapLayout),
                WrapOrientation.HorizontalThenVertical,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((WrapLayout)bindable).InvalidateLayout();
                });

        public static readonly BindableProperty ColumnSpacingProperty =
            BindableProperty.Create(
                "ColumnSpacing",
                typeof(double),
                typeof(WrapLayout),
                6.0,
                propertyChanged: (bindable, oldvalue, newvalue) =>
                {
                    ((WrapLayout)bindable).InvalidateLayout();
                });

        public static readonly BindableProperty RowSpacingProperty =
            BindableProperty.Create(
                "RowSpacing",
                typeof(double),
                typeof(WrapLayout),
                6.0,
                propertyChanged: (bindable, oldvalue, newvalue) =>
                {
                    ((WrapLayout)bindable).InvalidateLayout();
                });

        public WrapOrientation Orientation
        {
            set { SetValue(OrientationProperty, value); }
            get { return (WrapOrientation)GetValue(OrientationProperty); }
        }

        public double ColumnSpacing
        {
            set { SetValue(ColumnSpacingProperty, value); }
            get { return (double)GetValue(ColumnSpacingProperty); }
        }

        public double RowSpacing
        {
            set { SetValue(RowSpacingProperty, value); }
            get { return (double)GetValue(RowSpacingProperty); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            LayoutInfo layoutInfo = GetLayoutInfo(widthConstraint, heightConstraint);

            if (layoutInfo.VisibleChildCount == 0)
            {
                return new SizeRequest();
            }

            Size totalSize = new Size(layoutInfo.CellSize.Width * layoutInfo.Cols + 
                                        ColumnSpacing * (layoutInfo.Cols - 1),
                                      layoutInfo.CellSize.Height * layoutInfo.Rows + 
                                        RowSpacing * (layoutInfo.Rows - 1));

            return new SizeRequest(totalSize);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            LayoutInfo layoutInfo = GetLayoutInfo(width, height);

            if (layoutInfo.VisibleChildCount == 0)
                return;

            double xChild = x;
            double yChild = y;
            int row = 0;
            int col = 0;

            foreach (View child in Children)
            {
                if (!child.IsVisible)
                    continue;

                LayoutChildIntoBoundingRegion(child, 
                        new Rectangle(new Point(xChild, yChild), layoutInfo.CellSize));

                if (Orientation == WrapOrientation.HorizontalThenVertical)
                {
                    if (++col == layoutInfo.Cols)
                    {
                        col = 0;
                        row++;
                        xChild = x;
                        yChild += RowSpacing + layoutInfo.CellSize.Height;
                    }
                    else
                    {
                        xChild += ColumnSpacing + layoutInfo.CellSize.Width;
                    }
                }
                else // Orientation == WrapOrientation.VerticalThenHorizontal
                {
                    if (++row == layoutInfo.Rows)
                    {
                        col++;
                        row = 0;
                        xChild += ColumnSpacing + layoutInfo.CellSize.Width;
                        yChild = y;
                    }
                    else
                    {
                        yChild += RowSpacing + layoutInfo.CellSize.Height;
                    }
                }
            }
        }

        LayoutInfo GetLayoutInfo(double width, double height)
        {
            Size size = new Size(width, height);

            // Check if cached information is available.
            if (layoutInfoCache.ContainsKey(size))
            {
                return layoutInfoCache[size];
            }

            int visibleChildCount = 0;
            Size maxChildSize = new Size();
            int rows = 0;
            int cols = 0;
            LayoutInfo layoutInfo = new LayoutInfo();

            // Enumerate through all the children.
            foreach (View child in Children)
            {
                // Skip invisible children.
                if (!child.IsVisible)
                    continue;

                // Count the visible children.
                visibleChildCount++;

                // Get the child's requested size.
                SizeRequest childSizeRequest = child.Measure(Double.PositiveInfinity, 
                                                             Double.PositiveInfinity,
                                                             MeasureFlags.IncludeMargins);

                // Accumulate the maximum child size.
                maxChildSize.Width = 
                    Math.Max(maxChildSize.Width, childSizeRequest.Request.Width);

                maxChildSize.Height = 
                    Math.Max(maxChildSize.Height, childSizeRequest.Request.Height);
            }

            if (visibleChildCount != 0)
            {
                // Calculate the number of rows and columns.
                if (Orientation == WrapOrientation.HorizontalThenVertical)
                {
                    if (Double.IsPositiveInfinity(width))
                    {
                        cols = visibleChildCount;
                        rows = 1;
                    }
                    else
                    {
                        cols = (int)((width + ColumnSpacing) / 
                                    (maxChildSize.Width + ColumnSpacing));
                        cols = Math.Max(1, cols);
                        rows = (visibleChildCount + cols - 1) / cols;
                    }
                }
                else // WrapOrientation.VerticalThenHorizontal
                {
                    if (Double.IsPositiveInfinity(height))
                    {
                        rows = visibleChildCount;
                        cols = 1;
                    }
                    else
                    {
                        rows = (int)((height + RowSpacing) / 
                                    (maxChildSize.Height + RowSpacing));
                        rows = Math.Max(1, rows);
                        cols = (visibleChildCount + rows - 1) / rows;
                    }
                }

                // Now maximize the cell size based on the layout size.
                Size cellSize = new Size();

                if (Double.IsPositiveInfinity(width))
                {
                    cellSize.Width = maxChildSize.Width;
                }
                else
                {
                    cellSize.Width = (width - ColumnSpacing * (cols - 1)) / cols;
                }

                if (Double.IsPositiveInfinity(height))
                {
                    cellSize.Height = maxChildSize.Height;
                }
                else
                {
                    cellSize.Height = (height - RowSpacing * (rows - 1)) / rows;
                }

                layoutInfo = new LayoutInfo(visibleChildCount, cellSize, rows, cols);
            }

            layoutInfoCache.Add(size, layoutInfo);
            return layoutInfo;
        }

        protected override void InvalidateLayout()
        {
            base.InvalidateLayout();

            // Discard all layout information for children added or removed.
            layoutInfoCache.Clear();
        }

        protected override void OnChildMeasureInvalidated()
        {
            base.OnChildMeasureInvalidated();

            // Discard all layout information for child size changed.
            layoutInfoCache.Clear();
        }
    }
}
