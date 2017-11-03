using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class OverlapLayout : Layout<View>
    {
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(
                "Orientation",
                typeof(StackOrientation),
                typeof(OverlapLayout),
                StackOrientation.Vertical,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((OverlapLayout)bindable).InvalidateLayout();
                });

        public static readonly BindableProperty OffsetProperty =
            BindableProperty.Create(
                "Offset",
                typeof(double),
                typeof(OverlapLayout),
                20.0,
                propertyChanged: (bindable, oldvalue, newvalue) =>
                {
                    ((OverlapLayout)bindable).InvalidateLayout();
                });

        // Attached bindable property.
        public static readonly BindableProperty RenderOrderProperty =
            BindableProperty.CreateAttached("RenderOrder",
                                            typeof(int),
                                            typeof(OverlapLayout),
                                            0);

        // Helper methods for attached bindable property.
        public static int GetRenderOrder(BindableObject bindable)
        {
            return (int)bindable.GetValue(RenderOrderProperty);
        }

        public static void SetRenderOrder(BindableObject bindable, int order)
        {
            bindable.SetValue(RenderOrderProperty, order);
        }

        public StackOrientation Orientation
        {
            set { SetValue(OrientationProperty, value); }
            get { return (StackOrientation)GetValue(OrientationProperty); }
        }

        public double Offset
        {
            set { SetValue(OffsetProperty, value); }
            get { return (double)GetValue(OffsetProperty); }
        }

        // Monitor PropertyChanged events for items in the Children collection.
        protected override void OnAdded(View view)
        {
            base.OnAdded(view);
            view.PropertyChanged += OnChildPropertyChanged;
        }

        protected override void OnRemoved(View view)
        {
            base.OnRemoved(view);
            view.PropertyChanged -= OnChildPropertyChanged;
        }

        void OnChildPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "RenderOrder")
            {
                InvalidateLayout();
            }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, 
                                                 double heightConstraint)
        {
            int visibleChildCount = 0;
            Size maxChildSize = new Size();

            foreach (View child in Children)
            {
                if (!child.IsVisible)
                    continue;

                visibleChildCount++;

                // Get the child's desired size.
                SizeRequest childSizeRequest = new SizeRequest();

                if (Orientation == StackOrientation.Vertical)
                {
                    childSizeRequest = child.Measure(widthConstraint, 
                                                     Double.PositiveInfinity,
                                                     MeasureFlags.IncludeMargins);
                }
                else // Orientation == StackOrientation.Horizontal
                {
                    childSizeRequest = child.Measure(Double.PositiveInfinity, 
                                                     heightConstraint,
                                                     MeasureFlags.IncludeMargins);
                }

                // Find the maximum child width and height.
                maxChildSize.Width = Math.Max(maxChildSize.Width, 
                                              childSizeRequest.Request.Width);
                maxChildSize.Height = Math.Max(maxChildSize.Height, 
                                               childSizeRequest.Request.Height);
            }

            if (visibleChildCount == 0)
            {
                return new SizeRequest();
            }
            else if (Orientation == StackOrientation.Vertical)
            {
                return new SizeRequest(
                    new Size(maxChildSize.Width, 
                             maxChildSize.Height + Offset * (visibleChildCount - 1)));
            }
            else // Orientation == StackOrientation.Horizontal)
            {
                return new SizeRequest(
                    new Size(maxChildSize.Width + Offset * (visibleChildCount - 1), 
                             maxChildSize.Height));
            }
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            foreach (View child in Children)
            {
                if (!child.IsVisible)
                    continue;

                SizeRequest childSizeRequest = child.Measure(width, height, MeasureFlags.IncludeMargins);
                double childOffset = Offset * GetRenderOrder(child);

                if (Orientation == StackOrientation.Vertical)
                {
                    LayoutChildIntoBoundingRegion(child, 
                        new Rectangle(x, y + childOffset, 
                                      width, childSizeRequest.Request.Height));
                }
                else // Orientation == StackOrientation.Horizontal
                {
                    LayoutChildIntoBoundingRegion(child, 
                        new Rectangle(x + childOffset, y, 
                                      childSizeRequest.Request.Width, height));
                }
            }
        }
    }
}
